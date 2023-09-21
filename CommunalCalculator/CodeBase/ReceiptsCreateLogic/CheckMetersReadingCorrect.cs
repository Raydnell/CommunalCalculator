using CommunalCalculator.CodeBase.DBScripts.Models;

namespace CommunalCalculator.CodeBase.ReceiptsCreateLogic
{
    public class CheckMetersReadingCorrect
    {
        public bool Check(Receipt newReceipt, Receipt oldReceipt)
        {
            if (newReceipt.ColdWater >= oldReceipt.ColdWater &&
                newReceipt.HotWaterAmount >= oldReceipt.HotWaterAmount &&
                newReceipt.ElectricityDay >= oldReceipt.ElectricityDay &&
                newReceipt.ElectricityNight >= oldReceipt.ElectricityNight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
