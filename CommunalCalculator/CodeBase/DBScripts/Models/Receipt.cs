namespace CommunalCalculator.CodeBase.DBScripts.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public float ColdWater { get; set; }
        public double ColdWaterCost { get; set; }
        public float ElectricityDay { get; set; }
        public double ElectricityDayCost { get; set; }
        public float ElectricityNight { get; set; }
        public double ElectricityNightCost { get; set; }
        public float ElectricityStandart { get; set; }
        public double ElectricityStandartDayCost { get; set; }
        public float HotWaterAmount { get; set; }
        public double HotWaterAmountCost { get; set; }
        public float HotWaterEnergy { get; set; }
        public double HotWaterEnergyCost { get; set; }
        public double FullCost { get; set; }
        public int DayisInPeriod { get; set; }
        public int StandartModificator { get; set; }

        public Receipt()
        {
            DayisInPeriod = 1;
            StandartModificator = 1;
        }
    }
}
