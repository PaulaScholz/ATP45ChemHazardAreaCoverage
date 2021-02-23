using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AdvancedATP45.ChemHazard;


namespace ChemHazardCalculator
{
    [DataContract]
    public class ChemHazardViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        public const double ktsToMphFactor = 1.15077945;
        public const double ktsToKphFactor = 1.852;
        public const double ktsToMpsFactor = 0.51444444;

        public bool WpnNameEntered { get; set; }
        public bool AgentNameEntered { get; set; }
        public bool FillWeightEntered { get; set; }
        public bool WindspeedEntered { get; set; }
        public bool ThresholdEntered { get; set; }
        public bool ICT50Entered { get; set; }
        public bool LCT50Entered { get; set; }

        private string weaponName;
        /// The name or code of this collection of dosage patterns.
        /// </summary>
        [DataMember]
        public string WeaponName
        {
            get { return weaponName; }
            set { 
                    Set(ref weaponName, value);
                    WpnNameEntered = true;
                    CheckEnableCalculate();
                }
        }

        private string agentName;
        /// <summary>
        /// The name or code of the agent for this collection of dosage patterns.
        /// </summary>
        [DataMember]
        public string AgentName
        {
            get { return agentName; }
            set { 
                    Set(ref agentName, value);
                    AgentNameEntered = true;
                    CheckEnableCalculate();
                }
        }

        private double fillWeightKilograms;
        /// <summary>
        /// Original source strength in kilograms.
        /// </summary>
        [DataMember]
        public double Qkg
        {
            get { return fillWeightKilograms; }
            set { 
                    Set(ref fillWeightKilograms, value);
                    FillWeightEntered = true;
                    CheckEnableCalculate();
                }
        }

        private double windspeedKts;
        /// <summary>
        /// Windspeed in knots
        /// </summary>
        [DataMember]
        public double UKts
        {
            get { return windspeedKts; }
            set { 
                    Set(ref windspeedKts, value);
                    WindspeedEntered = true;
                    CheckEnableCalculate();
                }
        }

        private PasquillStabilityCategory psc = PasquillStabilityCategory.Neutral;
        /// <summary>
        /// The Pasquill Stability Category for the calculations
        /// </summary>
        [DataMember]
        public PasquillStabilityCategory Psc
        {
            get { return psc; }
            set { Set(ref psc, value); }
        }

        private TargetSurfaceType tst = TargetSurfaceType.Land;
        /// <summary>
        /// The TargetSurfaceType, Land or Sea
        /// </summary>
        [DataMember]
        public TargetSurfaceType Tst
        {
            get { return tst; }
            set 
            { 
                Set(ref tst, value); 

                if(tst == TargetSurfaceType.Land)
                {
                    // set the UI radio buttons
                    tstButtonLand = true;
                    tstButtonSea = false;
                }
                else
                {
                    tstButtonLand = false;
                    tstButtonSea = true;
                }
            }
        }

        private double thresholdDosageValue;
        /// <summary>
        /// Threshold effects dosage in mg.min/m^3
        /// </summary>
        [DataMember]
        public double ThresholdDosage
        {
            get { return thresholdDosageValue; }
            set { 
                    Set(ref thresholdDosageValue, value);
                    ThresholdEntered = true;
                    CheckEnableCalculate();
                }
        }

        private double ICT50DosageValue;
        /// <summary>
        /// ICT50 effects dosage in mg.min/m^3
        /// </summary>
        [DataMember]
        public double ICT50Dosage
        {
            get { return ICT50DosageValue; }
            set { 
                    Set(ref ICT50DosageValue, value);
                    ICT50Entered = true;
                    CheckEnableCalculate();
                }
        }

        private double LCT50DosageValue;
        /// <summary>
        /// LCT50 effects dosage in mg.min/m^3
        /// </summary>
        [DataMember]
        public double LCT50Dosage
        {
            get { return LCT50DosageValue; }
            set { 
                    Set(ref LCT50DosageValue, value);
                    LCT50Entered = true;
                    CheckEnableCalculate();
                }
        }

        private TotalDosagePattern calculatedPattern;

        /// <summary>
        /// The calculated total dosage pattern
        /// </summary>
        [DataMember]
        public TotalDosagePattern CalculatedPattern
        {
            get { return calculatedPattern; }
            set { Set(ref calculatedPattern, value); }
        }

        // for the UI, so no serialization
        // returns string of windspeedMPS value in KPH and MPH
        public string MphKphLabelString
        {
            get 
            {
                return string.Format("{0:N1} KPH, {1:N1} MPH, {2:N1} MPS", windspeedKts * ktsToKphFactor, windspeedKts * ktsToMphFactor, windspeedKts * ktsToMpsFactor);
            }
        }

        // these are for the UI, as radiobuttons bind to booleans
        // Note that they do not have the [DataMember] annotation 
        // and are not serialized.
        private bool tstButtonSea = false;
        public bool TSTButtonSea
        {
            get { return tstButtonSea; }

            set 
            { 
                tstButtonSea = value;

                if(tstButtonSea)
                {
                    Tst = TargetSurfaceType.Sea;
                }                        
            }           
        }

        private bool tstButtonLand = true;
        public bool TSTButtonLand
        {
            get { return tstButtonLand; }

            set
            {
                tstButtonLand = value;

                if (tstButtonLand)
                {
                    Tst = TargetSurfaceType.Land;
                }
            }
        }

        /// <summary>
        /// Make sure we've entered all the inputs before we enable the Calculate button.
        /// </summary>
        private void CheckEnableCalculate()
        {
            if ( WpnNameEntered && AgentNameEntered && FillWeightEntered && WindspeedEntered &&
                ThresholdEntered && ICT50Entered && LCT50Entered )
            {
                EnableCalculate = true;
            }
        }

        private bool enableCalculate = false;
        public bool EnableCalculate
        {
            get 
            {
                return enableCalculate;
            }

            set
            {
                Set(ref enableCalculate, value);
            }
        }
    }
    
}
