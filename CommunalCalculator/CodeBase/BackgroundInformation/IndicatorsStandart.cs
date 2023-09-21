namespace CommunalCalculator.CodeBase.BackgroundInformation
{
    public class IndicatorsStandart
    {
        public float ColdWater { get; set; }
        public float Electricity { get; set; }
        public float HotWaterAmount { get; set; }
        public float HotWaterEnergy { get; set; }

        public IndicatorsStandart()
        {
            ColdWater = 4.85f;
            Electricity = 164.0f;
            HotWaterAmount = 4.01f;
            HotWaterEnergy = 0.05349f;
        }
    }
}
