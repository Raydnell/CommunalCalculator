using System;
using CommunalCalculator.CodeBase.DBScripts;
using Spectre.Console;

namespace CommunalCalculator.CodeBase
{
    class StartUpInitialization
    {
        public void CheckConnectionToDB()
        {
            Console.Clear();
            
            using (ReceiptsDBContex indicationsDB = new ReceiptsDBContex())
            {
                if (!indicationsDB.Database.CanConnect())
                {
                    throw new Exception("cant connet to DB, check connection");
                }
            }
        }
    }
}
