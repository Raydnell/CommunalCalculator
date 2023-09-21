namespace CommunalCalculator.CodeBase.CalculationAlgorithms.RegulagCalculationAlgorithm
{
    public class RegularCostCalculationAlgorithm : IRegularCostCalculationAlgorithm
    {
        public float Calculate(float amount, float tariff)
        {
            return amount * tariff;
        }
    }
}
