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
            { EnumCreateRecepietMenu.RecepietAdd, "Показания внесены, расчёт можно посмотреть в квитанциях" },
            { EnumCreateRecepietMenu.InputIncorrect, "Некорректный ввод, повторите попытку" },
            { EnumViewReceipts.NoReceipts, "Нет квитанций" },
            { EnumViewReceipts.Id, "ID" },
            { EnumViewReceipts.ColdWater, "ХВС (м3/руб.)" },
            { EnumViewReceipts.HotWaterValue, "ГВС вода (м3/руб.)" },
            { EnumViewReceipts.HotWaterEnergy, "ГВС энергия (Гкал/руб.)" },
            { EnumViewReceipts.ElectricityStandart, "Электричество (без счётчика) (кВт.ч/руб.)" },
            { EnumViewReceipts.ElectricityDay, "Элекстричество день (кВт.ч/руб.)" },
            { EnumViewReceipts.ElectricityNight, "Элекстричество ночь (кВт.ч/руб.)" },
            { EnumViewReceipts.Total, "Итого (руб.)" },
            { EnumResidentsSet.SameResidentsAllTime, "Весь период проживало одно количество жильцов или разное?\n(Y - разное, N - одинаковое)" },
            { EnumResidentsSet.ChooseDaysInPeriod, "Дальше нужно будет указывать сколько дней сколько человек проживало в квартире, до тех пор, пока не будет заполнена информация по всему расчётному периоду. При неверном вводе будет указан 31 день.\nУкажите длительность расчётного периода\n " },
            { EnumResidentsSet.HowToSetVariousResidents, "Далее указывайте по порядку солько дней сколько проживало человек, например 10-1, 2-3, 12-1, 7-4\nНиже будет высвечиваться информация о том, сколько дней уже заполнено" },
            { EnumResidentsSet.ChooseDays, "Сколько дней проживало: " },
            { EnumResidentsSet.ChooseResidents, "Сколько было жильцов: " },
            { EnumResidentsSet.MoreDaysThenPeriod, "Указано больше дней, чем в текущем периоде, повторите попытку" },
            { EnumResidentsSet.FilledDays, "Заполнено дней " },
            { EnumResidentsSet.IncorrectInput, "Нужно вводить число, повторите попытку" }
        };
    }
}
