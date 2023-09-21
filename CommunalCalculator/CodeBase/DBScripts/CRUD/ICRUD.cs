using CommunalCalculator.CodeBase.DBScripts.Models;

namespace CommunalCalculator.CodeBase.DBScripts.CRUD
{
    public interface ICRUD
    {
        public void Create(Receipt receipt);
        public void Delete(int id);
        public Receipt GetReceipt(int id);
        public void Update(Receipt receipt);
        public ReceiptsDBContex GetReceiptsDB();
    }
}
