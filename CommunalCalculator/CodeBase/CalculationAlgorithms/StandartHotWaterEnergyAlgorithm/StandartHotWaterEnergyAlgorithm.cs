namespace CommunalCalculator.CodeBase.CalculationAlgorithms.StandartHotWaterEnergyAlgorithm
{
    public class StandartHotWaterEnergyAlgorithm : IStandartHotWaterEnergyAlgorithm
    {
        public float Calculate(float hotWaterAmount, float hotWaterEnergyStandart)
        {
            return hotWaterAmount * hotWaterEnergyStandart;
        }
    }
}
