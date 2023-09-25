using System;
using CommunalCalculator.CodeBase.DBScripts;

namespace CommunalCalculator.CodeBase
{
    class StartUpInitialization
    {
        public void CheckConnectionToDB()
        {
            using (ReceiptsDBContex indicationsDB = new ReceiptsDBContex())
            {
                if (!indicationsDB.Database.CanConnect())
                {
                    throw new Exception("Cant connect to DB, check connection");
                }
            }
        }
    }
}
