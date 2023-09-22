using System;
using System.Collections.Generic;
using CommunalCalculator.CodeBase.DBScripts.Models;

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
            Console.WriteLine("Весь период проживало одно количество жильцов или разное?\n(Y - разное, N - одинаковое)");
            var input = Console.ReadKey();
            switch (input.Key)
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
            Console.Clear();
            Console.WriteLine("Дальше нужно будет указывать сколько дней сколько человек проживало в квартире, до тех пор, пока не будет заполнена информация по всему расчётному периоду. При неверном вводе будет указан 31 день.\nУкажите длительность расчётного периода\n ");
            Console.WriteLine("1) 28");
            Console.WriteLine("2) 30");
            Console.WriteLine("3) 31");

            var inputKey = Console.ReadKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.D1:
                    return 28;

                case ConsoleKey.D2:
                    return 30;

                default:
                case ConsoleKey.D3:
                    return 31;
            }
        }

        private void FillDaysAndResidents(Receipt receipt)
        {
            int filledDays = 0;
            var DaysAndResidents = new List<int[]>();

            Console.Clear();
            Console.WriteLine("Далее указывайте по порядку солько дней сколько проживало человек, например 10-1, 2-3, 12-1, 7-4");
            Console.WriteLine("Ниже будет высвечиваться информация о том, сколько дней уже заполнено");

            _isComplete = false;
            while (_isComplete == false)
            {
                Console.Write("Сколько дней проживало: ");
                var days = TryParseString(Console.ReadLine());
                if (days == -66)
                {
                    continue;
                }
                else if (days + filledDays > receipt.DayisInPeriod)
                {
                    Console.WriteLine("Указано больше дней, чем в текущем периоде, повторите попытку");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Сколько было жильцов в эти дни: ");
                var residents = TryParseString(Console.ReadLine());
                if (residents == -66)
                {
                    continue;
                }

                DaysAndResidents.Add(new int[] { days, residents });

                filledDays = 0;
                foreach (var item in DaysAndResidents)
                {
                    filledDays += item[0];
                }

                Console.WriteLine($"Заполнено {filledDays} из {receipt.DayisInPeriod}");

                if (filledDays == receipt.DayisInPeriod)
                {
                    _isComplete = true;
                }
            }

            receipt.StandartModificator = 0;
            foreach (var item in DaysAndResidents)
            {
                receipt.StandartModificator += item[0] * item[1];
            }
        }

        private void ConstantResidentsInPeriod(Receipt receipt)
        {
            _isComplete = false;
            receipt.DayisInPeriod = 1;

            while (_isComplete == false)
            {
                Console.Clear();
                Console.Write("Сколько проживало жильцов: ");
                receipt.StandartModificator = TryParseString(Console.ReadLine());
                
                if (receipt.StandartModificator != -66)
                {
                    _isComplete = true;
                }
            }
        }

        private int TryParseString(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.Write("Нужно вводить число");
                Console.ReadKey();
            }

            return -66;
        }
    }
}
