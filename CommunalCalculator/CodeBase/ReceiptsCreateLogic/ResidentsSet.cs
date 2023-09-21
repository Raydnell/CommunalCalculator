namespace CommunalCalculator.CodeBase.ReceiptsCreateLogic
{
    public class ResidentsSet
    {
        public int HowMuchResidents(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return 1;
            }
        }
    }
}
