using System;
using CommunalCalculator.CodeBase.Localization;
using CommunalCalculator.CodeBase.Enums;

namespace CommunalCalculator.CodeBase.UserInterface
{
    public class MainMenu
    {
        private ConsoleKeyInfo _pressedKey;
        private bool _isNeedToExit;
        private CreateRecepietMenu _createIndication;
        private ViewReceiptsMenu _viewIndications;

        public MainMenu()
        {
            _pressedKey = new ConsoleKeyInfo();
            _createIndication = new CreateRecepietMenu();
            _viewIndications = new ViewReceiptsMenu();
        }

        public void SelectPoint()
        {
            while (_isNeedToExit == false)
            {
                Console.Clear();
                Console.WriteLine(Localizations.RussianLocalization[EnumMainMenu.MainMenu] + "\n");
                Console.WriteLine(Localizations.RussianLocalization[EnumMainMenu.AddNewIndication]);
                Console.WriteLine(Localizations.RussianLocalization[EnumMainMenu.ViewRecepiets]);
                Console.WriteLine(Localizations.RussianLocalization[EnumMainMenu.Exit] + "\n");
                Console.WriteLine(Localizations.RussianLocalization[EnumMainMenu.ForChooseUseDigits]);

                _pressedKey = Console.ReadKey();
                switch (_pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        _createIndication.StartCreateNewIndication();
                        break;

                    case ConsoleKey.D2:
                        _viewIndications.ShowReceiptsTable();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        _isNeedToExit = true;
                        break;
                }
            }
        }
    }
}
