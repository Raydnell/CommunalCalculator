using CommunalCalculator.CodeBase.DBScripts.Models;

namespace CommunalCalculator.CodeBase.DBScripts.DBOperations
{
    public class DBOperations : IDBOperations
    {
        private ReceiptsDBContex _receiptsDB;

        public DBOperations()
        {
            _receiptsDB = new ReceiptsDBContex();
        }

        public void Create(Receipt receipt)
        {
            _receiptsDB.Receipts.Add(receipt);
            _receiptsDB.SaveChanges();
        }

        public ReceiptsDBContex GetReceiptsDB()
        {
            return _receiptsDB;
        }
    }
}
