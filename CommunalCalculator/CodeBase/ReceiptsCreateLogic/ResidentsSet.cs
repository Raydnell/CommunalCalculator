using System;
using System.Collections.Generic;
using CommunalCalculator.CodeBase.DBScripts.Models;
using CommunalCalculator.CodeBase.Enums;
using CommunalCalculator.CodeBase.Localization;

namespace CommunalCalculator.CodeBase.ReceiptsCreateLogic
{
    public class ResidentsSet
    {
        private bool _isComplete;

        public ResidentsSet()
        {
            _isComplete = false;
        }

        public void HowMuchResidents(Receipt receipt)
        {
            Console.Clear();
            Console.WriteLine(Localizations.RussianLocalization[EnumResidentsSet.SameResidentsAllTime]);
            var inputKey = Console.ReadKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.Y:
                    DifferentResidentsInPeriod(receipt);
                    break;

                case ConsoleKey.N:
                    ConstantResidentsInPeriod(receipt);
                    break;
            }
        }

        private void DifferentResidentsInPeriod(Receipt receipt)
        {
            receipt.DayisInPeriod = HowMuchDaysInPeriod();
            FillDaysAndResidents(receipt);
            
        }

        private int HowMuchDaysInPeriod()
        {
            bool isCorrect;
            
            Console.Clear();
            Console.WriteLine(Localizations.RussianLocalization[EnumResidentsSet.ChooseDaysInPeriod]);
            Console.WriteLine("1) 28");
            Console.WriteLine("2) 30");
            Console.WriteLine("3) 31");

            isCorrect = false;
            while (isCorrect == false)
            {
                var inputKey = Console.ReadKey();
                switch (inputKey.Key)
                {
                    case ConsoleKey.D1:
                        return 28;

                    case ConsoleKey.D2:
                        return 30;

                    case ConsoleKey.D3:
                        return 31;

                    default:
                        Console.Write(Localizations.RussianLocalization[EnumResidentsSet.IncorrectInput]);
                        Console.ReadKey();
                        break;
                }
            }

            return 30;
        }

        private void FillDaysAndResidents(Receipt receipt)
        {
            var filledDays = 0;
            var DaysAndResidents = new List<(int,int)>();

            Console.Clear();
            Console.WriteLine(Localizations.RussianLocalization[EnumResidentsSet.HowToSetVariousResidents]);

            _isComplete = false;
            while (_isComplete == false)
            {
                Console.Write(Localizations.RussianLocalization[EnumResidentsSet.ChooseDays]);
                var days = TryParseString();
                if (days + filledDays > receipt.DayisInPeriod)
                {
                    Console.WriteLine(Localizations.RussianLocalization[EnumResidentsSet.MoreDaysThenPeriod]);
                    Console.ReadKey();
                    continue;
                }

                Console.Write(Localizations.RussianLocalization[EnumResidentsSet.ChooseResidents]);
                var residents = TryParseString();

                DaysAndResidents.Add(new (days, residents));

                filledDays = 0;
                foreach (var item in DaysAndResidents)
                {
                    filledDays += item.Item1;
                }

                Console.WriteLine($"{Localizations.RussianLocalization[EnumResidentsSet.FilledDays]}{filledDays}/{receipt.DayisInPeriod}");

                if (filledDays == receipt.DayisInPeriod)
                {
                    _isComplete = true;
                }
            }

            receipt.StandartModificator = 0;
            foreach (var item in DaysAndResidents)
            {
                receipt.StandartModificator += item.Item1 * item.Item2;
            }
        }

        private void ConstantResidentsInPeriod(Receipt receipt)
        {
            _isComplete = false;
            receipt.DayisInPeriod = 1;

            while (_isComplete == false)
            {
                Console.Clear();
                Console.Write(Localizations.RussianLocalization[EnumResidentsSet.ChooseResidents]);
                receipt.StandartModificator = TryParseString();
                
                if (receipt.StandartModificator != -66)
                {
                    _isComplete = true;
                }
            }
        }

        private int TryParseString()
        {
            var isCorrect = false;
            var inputLine = string.Empty;

            while (isCorrect == false)
            {
                inputLine = Console.ReadLine();

                if (int.TryParse(inputLine, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(Localizations.RussianLocalization[EnumResidentsSet.IncorrectInput]);
                    Console.ReadKey();
                }
            }

            return 0;
        }
    }
}
