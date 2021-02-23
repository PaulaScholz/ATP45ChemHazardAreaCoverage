
using NUnit.Framework;
using AdvancedATP45.ChemHazard;
using System;

namespace DosageUnitTests
{
    public class Tests
    {
        /// <summary>
        /// Test the ATP45 TotalDosage function using the unit test values in Suffield Memorandum 1275, A-5
        /// </summary>
        [Test]
        public void TotalDosage()
        {
            // 1000m downwind, 0 crosswind, windspeed 2 kts, 1 kilogram fill, land, very unstable, rounded to 5 decimal places
            Assert.AreEqual(.28161, Math.Round(Dosage.TotalDosage(1000, 0, 2, 1, TargetSurfaceType.Land, PasquillStabilityCategory.VeryUnstable), 5));

            // 5000m downwind, 0 crosswind, windspeed 2 kts, 1 kilogram fill, land, very unstable, rounded to 5 decimal places
            Assert.AreEqual(.02066, Math.Round(Dosage.TotalDosage(5000, 0, 2, 1, TargetSurfaceType.Land, PasquillStabilityCategory.VeryUnstable), 5));

            // 10000m downwind, 0 crosswind, windspeed 2 kts, 1 kilogram fill, land, very unstable, rounded to 5 decimal places
            Assert.AreEqual(.00667, Math.Round(Dosage.TotalDosage(10000, 0, 2, 1, TargetSurfaceType.Land, PasquillStabilityCategory.VeryUnstable), 5));

            // 40000m downwind, 0 crosswind, windspeed 2 kts, 1 kilogram fill, land, very unstable, rounded to 5 decimal places
            Assert.AreEqual(.00069, Math.Round(Dosage.TotalDosage(40000, 0, 2, 1, TargetSurfaceType.Land, PasquillStabilityCategory.VeryUnstable), 5));
        }
    }
}