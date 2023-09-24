using CommunalCalculator.CodeBase.DBScripts.Models;

namespace CommunalCalculator.CodeBase.DBScripts.DBOperations
{
    public interface IDBOperations
    {
        public void Create(Receipt receipt);
        public ReceiptsDBContex GetReceiptsDB();
    }
}
