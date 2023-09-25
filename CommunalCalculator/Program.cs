using System;
using CommunalCalculator.CodeBase.UserInterface;
using CommunalCalculator.CodeBase;

namespace CommunalCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            StartUpInitialization startUp = new StartUpInitialization();

            try
            {
                startUp.CheckConnectionToDB();
                mainMenu.SelectPoint();
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.WriteLine($"Some error happen, restart program.\nError message: {error}");
                Console.ReadKey();
            }
        }
    }
}
