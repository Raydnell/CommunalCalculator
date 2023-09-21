namespace CommunalCalculator.CodeBase.BackgroundInformation
{
    public class CalculationsTariffs
    {
        public float ColdWater { get; set; }
        public float Electricity { get; set; }
        public float ElectricityDay { get; set; }
        public float ElecticityNight { get; set; }
        public float HotWaterAmount { get; set; }
        public float HotWaterEnergy { get; set; }

        public CalculationsTariffs()
        {
            ColdWater = 35.78f;
            Electricity = 4.28f;
            ElectricityDay = 4.9f;
            ElecticityNight = 2.31f;
            HotWaterAmount = 35.78f;
            HotWaterEnergy = 998.69f;
        }
    }
}
