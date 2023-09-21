using System;
using System.Collections.Generic;
using CommunalCalculator.CodeBase.Enums;

namespace CommunalCalculator.CodeBase.Localization
{
    public class Localizations
    {
        public static Dictionary<Enum, string> RussianLocalization = new Dictionary<Enum, string>()
        {
            { EnumMainMenu.MainMenu, "Главное меню:" },
            { EnumMainMenu.AddNewIndication, "1) Добавить новое показание" },
            { EnumMainMenu.ViewRecepiets, "2) Просмотр квитанций" },
            { EnumMainMenu.Exit, "3) Выход" },
            { EnumMainMenu.ForChooseUseDigits, "Для выбора пункта используйте цифры" },
            { EnumMetersTypes.ColdWaterMeter, "Счётчик холодной воды" },
            { EnumMetersTypes.HotWaterMeter, "Счётчик горячей воды" },
            { EnumMetersTypes.ElectricityMeter, "Счётчик электричества" },
            { EnumMetersTypes.ElectricityDayMeter, "Счётчик электричества (День)" },
            { EnumMetersTypes.ElectricityNightMeter, "Счётчик электричества (Ночь)" },
            { EnumCreateRecepietMenu.ChooseWhatMeterYouHave, "Укажите, какие счётчики у вас имеются? (Y - есть, N - нет)" },
            { EnumCreateRecepietMenu.Yes, "Да" },
            { EnumCreateRecepietMenu.No, "Нет" },
            { EnumCreateRecepietMenu.HowManyResidents, "Сколько проживает человек в помещении?" },
            { EnumCreateRecepietMenu.SpecifyMetersReadings, "Укажите показатели для:" },
            { EnumCreateRecepietMenu.ErrorMetersNotCorrect, "Ошибка! Показания счётчиков меньше, чем показания за прошлый период." },
            { EnumCreateRecepietMenu.RecepietAdd, "Показания внесены, расчёт можно посмотреть в квитанциях" }
        };
    }
}
