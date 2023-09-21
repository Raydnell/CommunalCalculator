using System;
using CommunalCalculator.CodeBase.DBScripts.Models;

namespace CommunalCalculator.CodeBase.DBScripts.CRUD
{
    class CRUDSQLite : ICRUD, IDisposable
    {
        private ReceiptsDBContex _receiptsDB;

        public CRUDSQLite()
        {
            _receiptsDB = new ReceiptsDBContex();
        }

        public void Create(Receipt receipt)
        {
            _receiptsDB.Receipts.Add(receipt);
            _receiptsDB.SaveChanges();
        }

        public void Delete(int id)
        {
            var receipt = GetReceipt(id);
            _receiptsDB.Receipts.Remove(receipt);
            _receiptsDB.SaveChanges();
        }

        public Receipt GetReceipt(int id)
        {
            var receipt = _receiptsDB.Receipts.Find(id);

            if (receipt != null)
            {
                return receipt;
            }
            else
            {
                throw new Exception("Показания с таким id не найдено");
            }
        }

        public void Update(Receipt receipt)    
        {
            var receiptInDB = GetReceipt(receipt.Id);
            receiptInDB = receipt;
            _receiptsDB.SaveChanges();
        }

        public ReceiptsDBContex GetReceiptsDB()
        {
            return _receiptsDB;
        }

        public void Dispose()
        {
            _receiptsDB.Dispose();
        }
    }
}
