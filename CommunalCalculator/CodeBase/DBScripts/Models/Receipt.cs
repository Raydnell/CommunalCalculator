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
        public float Residents { get; set; }

        public Receipt()
        {
            ColdWater = 0.0f;
            ColdWaterCost = 0.0f;
            ElectricityDay = 0.0f;
            ElectricityDayCost = 0.0f;
            ElectricityNight = 0.0f;
            ElectricityNightCost = 0.0f;
            ElectricityStandart = 0.0f;
            ElectricityStandartDayCost = 0.0f;
            HotWaterAmount = 0.0f;
            HotWaterAmountCost = 0.0f;
            HotWaterEnergy = 0.0f;
            HotWaterEnergyCost = 0.0f;
            FullCost = 0.0f;
            Residents = 0.0f;
        }
    }
}
