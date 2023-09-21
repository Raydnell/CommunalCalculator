namespace CommunalCalculator.CodeBase.CalculationAlgorithms.HotWaterEnergyCalculation
{
    public class StandartValueAlgorithm : IStandartValueAlgorithm
    {
        public float Calculate(float amount, int residents)
        {
            return amount * (float)residents;
        }
    }
}
