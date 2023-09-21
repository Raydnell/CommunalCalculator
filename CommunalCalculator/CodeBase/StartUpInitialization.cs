using System;
using CommunalCalculator.CodeBase.DBScripts;
using Spectre.Console;

namespace CommunalCalculator.CodeBase
{
    class StartUpInitialization
    {
        private ReceiptsDBContex _indicationsDB;

        public StartUpInitialization()
        {
            _indicationsDB = new ReceiptsDBContex();
        }

        public void CheckConnectionToDB()
        {
            Console.Clear();
            
            if (_indicationsDB.Database.CanConnect())
            {
                AnsiConsole.Markup("[underline red]Подключение к БД успешно[/]");
            }
            else
            {
                AnsiConsole.Markup("[underline red]Подключение к БД неудачно[/]");
            }

            Console.ReadKey();
        }
    }
}
