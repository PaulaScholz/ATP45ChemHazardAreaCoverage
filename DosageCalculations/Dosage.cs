using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace AdvancedATP45.ChemHazard
{
    public enum TargetSurfaceType
    {
        Land,
        Sea
    }

    public enum PasquillStabilityCategory
    {
        VeryUnstable,
        Unstable,
        SlightlyUnstable,
        Neutral,
        SlightlyStable,
        Stable,
        VeryStable
    }

    /// <summary>
    /// Defines a dosage pattern for a particular combination of weapon input parameters.
    /// </summary>
    [DataContract]
    public class TotalDosagePattern
    {
        /// <summary>
        /// The name or code of this collection of dosage patterns.
        /// </summary>
        [DataMember]
        public string WeaponName { get; set; }

        /// <summary>
        /// The name or code of the agent for this collection of dosage patterns.
        /// </summary>
        [DataMember]
        public string AgentName { get; set; }

        /// <summary>
        /// Original source strength in kilograms.
        /// </summary>
        [DataMember]
        public double Qkg { get; set; }

        /// <summary>
        /// Windspeed in meters per second.
        /// </summary>
        [DataMember]
        public double UKts { get; set; }

        /// <summary>
        /// The Pasquill Stability Category for the calculations
        /// </summary>
        [DataMember]
        public PasquillStabilityCategory Psc { get; set; }

        /// <summary>
        /// The TargetSurfaceType, Land or Sea
        /// </summary>
        [DataMember]
        public TargetSurfaceType Tst { get; set; }

        /// <summary>
        /// The list of DosageField patterns for this TotalDosagePattern
        /// </summary>
        [DataMember]
        public List<DosageField> Patterns { get; set; }

        /// <summary>
        /// Tolerance value for dosage field calculations in mg.min/m^3.  Set to .02 in constructors.
        /// If you want a different one, set it before you call CalculateDosageField().
        /// </summary>
        [DataMember]
        public double Tolerance { get; set; }

        private double _toleranceLowerLimit;
        private double _toleranceUpperLimit;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TotalDosagePattern()
        {
            WeaponName = "auto";
            Psc = PasquillStabilityCategory.Neutral;
            Tst = TargetSurfaceType.Land;
            Tolerance = .02;        // .02 mg.min/m3
            Patterns = new List<DosageField>();
        }

        /// <summary>
        /// Constructor with all parameters.
        /// </summary>
        /// <param name="wpnName">Weapon Name</param>
        /// <param name="agentName">Agent Name</param>
        /// <param name="qkg">Fill weight in kilograms</param>
        /// <param name="ukts">Windspeed in knots</param>
        /// <param name="psc">Pasquill Stability Category</param>
        /// <param name="tst">Target Surface Type</param>
        public TotalDosagePattern(string wpnName, string agentName, double qkg, double ukts, PasquillStabilityCategory psc, TargetSurfaceType tst)
        {
            WeaponName = wpnName;
            AgentName = agentName;
            Qkg = qkg;
            UKts = ukts;
            Psc = psc;
            Tst = tst;
            Tolerance = .02;     // .02 mg.min/m3
            Patterns = new List<DosageField>();
        }

        /// <summary>
        /// Just provides an example of how to calculate dosage patterns.
        /// </summary>
        public virtual void Init()
        {
            Patterns.Add(CalculateDosagePattern(1));      // myosis
            Patterns.Add(CalculateDosagePattern(35));     // ICT50
            Patterns.Add(CalculateDosagePattern(70));     // LCT50;
        }

        /// <summary>
        /// Calculates the dosage field for the TotalDosagePattern's fill and met parameters
        /// and returns a DosageField object with pattern statistics and extents.
        /// </summary>
        /// <param name="threshold">Agent threshold of interest in mg.min/m^3</param>
        /// <returns>DosageField object with statistics and pattern.</returns>
        public DosageField CalculateDosagePattern(double threshold)
        {
            double numberOfSlices = 30;

            // make an object to return
            DosageField retVar = new DosageField(threshold);
            retVar.Threshold = threshold;

            // find the x distance for this threshold dosage
            var totalDistX = FindXLimitForDosage(Qkg, UKts, threshold, .01, Tst, Psc);
            retVar.MaxDownwindDistance = totalDistX.XMeters;

            double metersPerSlice = totalDistX.XMeters / numberOfSlices;

            DosageValue crosswindValue;

            for (int i = 1; i < numberOfSlices; i++)
            {
                double xDistance = i * metersPerSlice;

                crosswindValue = FindYLimitForDosage(xDistance, Qkg, UKts, threshold, Tolerance, Tst, Psc);
                crosswindValue.XMeters = xDistance;

                // accumulate statistics
                if (crosswindValue.YMeters > retVar.MaxCrosswindDistance) retVar.MaxCrosswindDistance = crosswindValue.YMeters;

                // multiply times 2 for both sides of the cloud
                retVar.AreaCovergeSquareMeters += (metersPerSlice * crosswindValue.YMeters * 2);

                retVar.DosageValues.Add(crosswindValue);
            }

            return retVar;
        }

        private bool WithinToleranceLimits(double testVal)
        {
            return (testVal >= _toleranceLowerLimit && testVal <= _toleranceUpperLimit);
        }

        private bool BelowToleranceLimits(double testVal)
        {
            return testVal < _toleranceLowerLimit;
        }

        private bool AboveToleranceLimits(double testval)
        {
            return testval > _toleranceUpperLimit;
        }

        /// <summary>
        /// Computes the downwind distance X for a dosage threshold with tolerance.
        /// </summary>
        /// <param name="endPointThreshold">Dosage in mg.min/m^3</param>
        /// <param name="tolerance">Tolerance for bisection in mg.min/m^3</param>
        /// <param name="crosswind">True if for crosswind distance Y calculation, X otherwise</param>
        /// <returns></returns>
        public DosageValue FindXLimitForDosage(double qKg, double uKts, double endPointThreshold, double tolerance,
                                                            TargetSurfaceType tst, PasquillStabilityCategory psc)
        {
            // sanity check on tolerance
            if (tolerance <= 0)
            {
                tolerance = endPointThreshold / 20;
            }

            // set the tolerance limits, depending on what we were passed.
            _toleranceLowerLimit = endPointThreshold - tolerance;
            _toleranceUpperLimit = endPointThreshold + tolerance;

            DosageValue retVal = new DosageValue();

            // set the initial guess at 1 meter
            var initialX = (distance: 1.0, dosage: 0.0);

            // twice that for limitX
            var limitX = (distance: initialX.distance * 2, dosage: 0.0);

            // the dosage at the initial distance
            initialX.dosage = Dosage.TotalDosage(initialX.distance, 0, uKts, qKg, tst, psc);

            // the dosage at the limit distance
            limitX.dosage = Dosage.TotalDosage(limitX.distance, 0, uKts, qKg, tst, psc);

            // adjust the limitX.distance until limitX.dosage drops below _toleranceLowerLimit
            while (limitX.dosage > _toleranceLowerLimit)
            {
                // move the initialX.distance up
                initialX.distance = limitX.distance;
                initialX.dosage = limitX.dosage;

                // double the distance
                limitX.distance *= 2;   // double it

                // test it again
                limitX.dosage = Dosage.TotalDosage(limitX.distance, 0, uKts, qKg, tst, psc);
            }

            // we now have a condition where the distance we want is between the initialX.distance
            // and the limitX.distance

            double oldDistance;
            double oldDosage;

            // converge to a distance within tolerance limits
            while (!WithinToleranceLimits(initialX.dosage))
            {
                // save the initialX data
                oldDistance = initialX.distance;
                oldDosage = initialX.dosage;

                // adjust and compute new dosage
                initialX.distance = (initialX.distance + limitX.distance) / 2;
                initialX.dosage = Dosage.TotalDosage(initialX.distance, 0, uKts, qKg, tst, psc);

                if (BelowToleranceLimits(initialX.dosage))
                {
                    // we're too high, so adjust it down
                    limitX.distance = initialX.distance;
                    limitX.dosage = initialX.dosage;

                    // restore the old numbers, a new initialX will be computed next pass
                    // using the new limitX.distance
                    initialX.distance = oldDistance;
                    initialX.dosage = oldDosage;
                }
            }

            // set the return value if within tolerance limits
            if (WithinToleranceLimits(initialX.dosage))
            {
                retVal.Dosage = initialX.dosage;
                retVal.XMeters = initialX.distance;
                retVal.YMeters = 0;
            }

            return retVal;
        }


        /// <summary>
        /// Computes the crosswind distance Y for a dosage threshold with tolerance.
        /// </summary>
        /// <param name="endPointThreshold">Dosage in mg.min/m^3</param>
        /// <param name="tolerance">Tolerance for bisection in mg.min/m^3</param>
        /// <param name="crosswind">True if for crosswind distance Y calculation, X otherwise</param>
        /// <returns></returns>
        public DosageValue FindYLimitForDosage(double xDistance, double qKg, double uKts, double endPointThreshold, double tolerance,
                                                            TargetSurfaceType tst, PasquillStabilityCategory psc)
        {
            // sanity check on tolerance
            if (tolerance <= 0)
            {
                tolerance = endPointThreshold / 20;
            }

            // set the tolerance limits, depending on what we were passed.
            _toleranceLowerLimit = endPointThreshold - tolerance;
            _toleranceUpperLimit = endPointThreshold + tolerance;

            DosageValue retVal = new DosageValue();

            // set the initial Y at 1 meter
            var initialY = (distance: 1.0, dosage: 0.0);

            // twice that for limitY
            var limitY = (distance: initialY.distance * 2, dosage: 0.0);

            // the dosage at the initial distance
            initialY.dosage = Dosage.TotalDosage(xDistance, initialY.distance, uKts, qKg, tst, psc);

            // the dosage at the limit distance
            limitY.dosage = Dosage.TotalDosage(xDistance, limitY.distance, uKts, qKg, tst, psc);

            // adjust the limitX.distance until limitY.dosage drops below _toleranceLowerLimit
            while (limitY.dosage > _toleranceLowerLimit)
            {
                // move the initialY.distance up
                initialY.distance = limitY.distance;
                initialY.dosage = limitY.dosage;

                // double the distance
                limitY.distance *= 2;   // double it

                // test it again
                limitY.dosage = Dosage.TotalDosage(xDistance, limitY.distance, uKts, qKg, tst, psc);
            }

            // we now have a condition where the distance we want is between the initialY.distance
            // and the limitY.distance

            double oldDistance;
            double oldDosage;

            // converge to a distance within tolerance limits
            while (!WithinToleranceLimits(initialY.dosage))
            {
                // save the initialY data
                oldDistance = initialY.distance;
                oldDosage = initialY.dosage;

                // adjust and compute new dosage
                initialY.distance = (initialY.distance + limitY.distance) / 2;
                initialY.dosage = Dosage.TotalDosage(xDistance, initialY.distance, uKts, qKg, tst, psc);

                if (BelowToleranceLimits(initialY.dosage))
                {
                    // we're too high, so adjust it down
                    limitY.distance = initialY.distance;
                    limitY.dosage = initialY.dosage;

                    // restore the old numbers, a new initialY will be computed next pass
                    // using the new limitY.distance
                    initialY.distance = oldDistance;
                    initialY.dosage = oldDosage;
                }
            }

            // set the return value if within tolerance limits
            if (WithinToleranceLimits(initialY.dosage))
            {
                retVal.Dosage = initialY.dosage;
                retVal.XMeters = 0;
                retVal.YMeters = initialY.distance;
            }

            return retVal;
        }
    }

    /// <summary>
    /// An individual point in a DosageField
    /// </summary>
    [DataContract]
    public class DosageValue
    {
        [DataMember]
        public double XMeters { get; set; }

        [DataMember]
        public double YMeters { get; set; }

        [DataMember]
        public double Dosage { get; set; }
    }

    /// <summary>
    /// An effects pattern for a particular threshold dosage.
    /// </summary>
    [DataContract]
    public class DosageField
    {
        // dosage value of this field in mg.min/m^3
        [DataMember]
        public double Threshold { get; set; }

        [DataMember]
        public double MaxDownwindDistance { get; set; }

        [DataMember]
        public double MaxCrosswindDistance { get; set; }

        [DataMember]
        public double AreaCovergeSquareMeters { get; set; }

        [DataMember]
        public List<DosageValue> DosageValues { get; set; }

        public DosageField()
        {
            Threshold = 0;
            DosageValues = new List<DosageValue>();
        }

        public DosageField(double threshold)
        {
            Threshold = threshold;
            DosageValues = new List<DosageValue>();
        }
    }

    /// <summary>
    /// Calculates dosage based on a Fortran Program for Calculating Chemical Hazards
    /// using the NATO STANAG 2103/ATP45 Algorithm by Stanley B. Mellsen, Oct 1989
    /// </summary>
    public static class Dosage
    {
        public const double KtsToMetersPerSecondFactor = 0.5144;
        public const double KilogramsToMilligramsFactor = 1000000.0;

        /// <summary>
        /// Calculate total dosage given along-wind coordinates, windspeed, source strength, surface type and stability.
        /// </summary>
        /// <param name="x">Downwind distance from release in meters.</param>
        /// <param name="y">Crosswind distance from release in meters.</param>
        /// <param name="uKts">Wind speed in knots.</param>
        /// <param name="qKg">Source Strength of release in kilograms.</param>
        /// <param name="ts">Target surface type, Land or Sea</param>
        /// <param name="s">Pasquill stability category</param>
        /// <returns></returns>
        public static double TotalDosage(double x, double y, double uKts, double qKg, TargetSurfaceType ts, PasquillStabilityCategory s)
        {
            double windSpeedMetersPerSecond = uKts * KtsToMetersPerSecondFactor;
            double sourceStrengthMilligrams = qKg * KilogramsToMilligramsFactor;

            // the enum is zero-based, so add one
            double stabilityCategory = (int)s + 1;

            // set up constants from Suffield Memorandum No. 1275

            // Land constants first

            // Scalar used in calculation of instantaneous sigma y
            double F1Scalar = 0.2997 * Math.Exp(0.2621 * stabilityCategory);

            // exponent of downwind distance used in calculation of sigma y
            double F1Exponent = 0.89 - (.07 * stabilityCategory);

            // scalar used in calculation of instantaneous sizma z
            double GScalar = 0.1229 * Math.Exp(0.3295 * stabilityCategory);

            // exponent used in calculation of instantaneous sigma z
            double GExponent = 0.97 - (0.09 * stabilityCategory);

            // scalar used in calculation of meander sigma y
            double FMScalar;

            if (uKts < 10.0)
            {
                FMScalar = 1.577;
            }
            else
            {
                FMScalar = 1.130;
            }

            // exponent used in calculation of meander sigma y
            // same for land or sea
            double FMExponent = 0.7;

            double velocityDeposition = 0.004;

            // if we're at sea, set up the constants that change at sea
            if (ts == TargetSurfaceType.Sea)
            {
                F1Scalar = 0.4570 * Math.Exp(-0.0863 * stabilityCategory);
                F1Exponent = 0.7;
                GScalar = 0.9740 * Math.Exp(0.1750 * stabilityCategory);
                GExponent = 0.68 - (0.06 * stabilityCategory);

                if (uKts < 10.0)
                {
                    FMScalar = 1.538;
                }
                else
                {
                    FMScalar = 1.038;
                }

                velocityDeposition = 0.003;
            }

            // calcualte standard deviations of plume
            double sigmaY_instantaneous = F1Scalar * Math.Pow(x, F1Exponent);

            double sigmaY_meander = FMScalar * Math.Pow(x, FMExponent);

            double sigmaY = Math.Sqrt(Math.Pow(sigmaY_instantaneous, 2) + Math.Pow(sigmaY_meander, 2));

            double sigmaZ = GScalar * Math.Pow(x, GExponent);

            // upper limit of error function integral
            double gamma = velocityDeposition * x / (Math.Sqrt(2) * windSpeedMetersPerSecond * GExponent * sigmaZ);

            double area = Gauss(0.0, gamma, 15);

            double erf = (2.0 / Math.Sqrt(Math.PI)) * area;

            double erfC = 1.0 - erf;

            double term1 = sourceStrengthMilligrams / (Math.PI * windSpeedMetersPerSecond * sigmaY * sigmaZ * 60.0);

            double term2 = Math.Exp(-Math.Pow(y, 2) / (2 * Math.Pow(sigmaY, 2)));

            double term3 = 1.0 - Math.Sqrt(Math.PI) * gamma * Math.Exp(Math.Pow(gamma, 2)) * erfC;

            double dosage = term1 * term2 * term3;

            return dosage;
        }

        private static double Functn(double x)
        {
            return Math.Exp(-Math.Pow(x, 2));
        }


        // Comments directly taken from the FORTRAN program:
        //
        // THE FUNCTION GAUSS USES THE M POINT GAUSS-LEGENDRE QUADRATURE
        // FORMULA TO COMPUTE THE INTEGRAL OF FUNCTN(X)*DX BETWEEN
        // INTEGRATION LIMITS A AND B.THE ROOTS OF SEVEN LEGENDRE
        // POLYNOMIALS AND THE WEIGHT FACTORS FOR THE CORRESPONDING
        // QUADRATURES ARE STORED IN THE Z AND WEIGHT ARRAYS
        // RESPECTIVELY.M MAY ASSUME VALUES 2,3,4,5,6,10, AND 15
        // ONLY.THE APPROPRIATE VALUES FOR THE M POINT FORMULA ARE
        // LOCATED IN ELEMENTS Z(KEY(I))...Z(KEY(I+1)-1) AND
        // WEIGHT(KEY(I))...WEIGHT(KEY(I+1)-1)  WHERE THE PROPER
        // VALUE OF  I IS DETERMINED BY FINDING THE SUBSCRIPT OF THE
        // ELEMENT OF THE ARRAY NPOINT WHICH HAS THE VALUE M.IF AN
        // INVALID VALUE OF M IS USED, A TRUE ZERO IS  RETURNED AS THE
        // VALUE OF GAUSS.
        //
        private static double Gauss(double a, double b, int m)
        {
            // number of valid points for the calculation
            int[] nPoint = { 2, 3, 4, 5, 6, 10, 15 };

            // These were adjusted from the Fortran program for C# zero-based arrays.
            // Fortran bases its arrays at 1, because men were men, and they all wore an 
            // onion on their belts because it was the style at the time.
            int[] key = { 0, 1, 3, 5, 8, 11, 16, 24 };

            double[] z = {0.577350269, 0.0, 0.774596669, 0.339981044,
                          0.861136312, 0.0, 0.538469310, 0.906179846,
                          0.238619186, 0.661209387, 0.932469514, 0.148874339,
                          0.433395394, 0.679409568, 0.865063367, 0.973906529,
                          0.0, 0.201194094, 0.394151347, 0.570972173, 0.724417731,
                          0.848206583, 0.937273392, 0.987992518 };

            double[] weight = { 1.0, 0.888888889, 0.555555556, 0.652145155,
                                0.347854645, 0.568888889, 0.478628671, 0.236926885,
                                0.467913935, 0.360761573, 0.171324493, 0.295524225,
                                0.269266719, 0.219086363, 0.149451349, 0.066671344,
                                0.202578242, 0.198431485, 0.186161000, 0.166269206,
                                0.139570678, 0.107159221, 0.070366047, 0.030753242 };

            // this mirrors the structure of the old FORTRAN program.  Don't judge me.
            int index = -1;

            for (int i = 0; i < 7; i++)
            {
                if (m == nPoint[i])
                {
                    index = i;
                    break;
                }
            }

            // we didn't find a proper M index, so return 0
            if (index == -1) return 0;

            // set up initial parameters
            int jFirst = key[index];
            int jLast = key[index + 1] - 1;

            double c = (b - a) / 2.0;
            double d = (b + a) / 2.0;
            double sum = 0;

            // accumulate the sum in the M Point formula
            for (int j = jFirst; j <= jLast; j++)
            {
                if (z[j] == 0.0)
                {
                    sum = sum + weight[j] * Functn(d);
                }
                else
                {
                    sum = sum + weight[j] * (Functn(z[j] * c + d) + Functn(-z[j] * c + d));
                }
            }

            return c * sum;
        }
    }
}

