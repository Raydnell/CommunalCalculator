using System;
using System.Collections.Generic;
using CommunalCalculator.CodeBase.Enums;
using CommunalCalculator.CodeBase.Localization;

namespace CommunalCalculator.CodeBase.ReceiptsCreateLogic
{
    public class CheckHasMeters
    {
        private ConsoleKeyInfo _pressedKey;

        public CheckHasMeters()
        {
            _pressedKey = new ConsoleKeyInfo();
        }

        public void Check(Dictionary<Enum, bool> metersChecks)
        {
            var isCorrect = false;
            var meters = new List<EnumMetersTypes>()
            {
                EnumMetersTypes.ColdWaterMeter,
                EnumMetersTypes.HotWaterMeter,
                EnumMetersTypes.ElectricityMeter
            };

            Console.Clear();
            Console.WriteLine(Localizations.RussianLocalization[EnumCreateRecepietMenu.ChooseWhatMeterYouHave] + "\n");

            foreach (var item in meters)
            {
                Console.Write($"> {Localizations.RussianLocalization[item]}?");

                isCorrect = false;
                while (isCorrect == false)
                {
                    _pressedKey = Console.ReadKey();
                    if (_pressedKey.Key == ConsoleKey.Y)
                    {
                        metersChecks[item] = true;
                        Console.Write($" - {Localizations.RussianLocalization[EnumCreateRecepietMenu.Yes]}\n");
                        isCorrect = true;
                    }
                    else if (_pressedKey.Key == ConsoleKey.N)
                    {
                        Console.Write($" - {Localizations.RussianLocalization[EnumCreateRecepietMenu.No]}\n");
                        isCorrect = true;
                    }
                    else
                    {
                        Console.Write($" - {Localizations.RussianLocalization[EnumCreateRecepietMenu.InputIncorrect]}\n");
                    }

                }
            }

            if (metersChecks[EnumMetersTypes.ElectricityMeter] == true)
            {
                metersChecks[EnumMetersTypes.ElectricityDayMeter] = true;
                metersChecks[EnumMetersTypes.ElectricityNightMeter] = true;
            }
        }
    }
}
