using System;
using CommunalCalculator.CodeBase.UserInterface;

namespace CommunalCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu _mainMenu = new MainMenu();

            //StartUpInitialization startUp = new StartUpInitialization();
            //startUp.CheckConnectionToDB();

            try
            {
                _mainMenu.SelectPoint();
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.WriteLine("Some error happen, restart program.");
                Console.WriteLine("\nError message:\n");
                Console.WriteLine(error);
                Console.ReadLine();
            }
        }
    }
}
