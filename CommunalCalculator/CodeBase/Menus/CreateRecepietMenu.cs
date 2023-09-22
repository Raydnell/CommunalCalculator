using System;
using System.Collections.Generic;
using System.Linq;
using CommunalCalculator.CodeBase.Enums;
using CommunalCalculator.CodeBase.Localization;
using CommunalCalculator.CodeBase.DBScripts.Models;
using CommunalCalculator.CodeBase.DBScripts.CRUD;
using CommunalCalculator.CodeBase.ReceiptsCreateLogic;

namespace CommunalCalculator.CodeBase.UserInterface
{
    public class CreateRecepietMenu
    {
        private ICRUD _dbCRUD;
        private ResidentsSet _residentsSet;
        private CheckHasMeters _checkHasMeters;
        private FillMetersReadings _fillMetersReadings;
        private CheckMetersReadingCorrect _checkMetersReadingCorrect;
        private CalculateCost _calculateCost;

        public CreateRecepietMenu()
        {
            _dbCRUD = new CRUDSQLite();
            _residentsSet = new ResidentsSet();
            _checkHasMeters = new CheckHasMeters();
            _fillMetersReadings = new FillMetersReadings();
            _checkMetersReadingCorrect = new CheckMetersReadingCorrect();
            _calculateCost = new CalculateCost();
        }

        public void StartCreateNewIndication()
        {
            var newReceipt = new Receipt();
            var previousReceipt = new Receipt();
            var metersCheck = new Dictionary<Enum, bool>()
            {
                { EnumMetersTypes.ColdWaterMeter, false },
                { EnumMetersTypes.HotWaterMeter, false },
                { EnumMetersTypes.ElectricityMeter, false }
            };
            var meters = new List<EnumMetersTypes>()
            {
                EnumMetersTypes.ColdWaterMeter,
                EnumMetersTypes.HotWaterMeter,
                EnumMetersTypes.ElectricityMeter
            };

            if (_dbCRUD.GetReceiptsDB().Receipts.Count() > 0)
            {
                previousReceipt = _dbCRUD.GetReceiptsDB().Receipts.OrderBy(r => r.Id).Last();
            }

            //указание количества жильцов
            _residentsSet.HowMuchResidents(newReceipt);

            //указание имеющихся счётчиков
            _checkHasMeters.Check(metersCheck);

            //заполнение показаний счётчиков
            _fillMetersReadings.Fill(newReceipt, previousReceipt, metersCheck);

            //проверка корректности показаний в сравнении с прошлыми показаниями
            if (!_checkMetersReadingCorrect.Check(newReceipt, previousReceipt))
            {
                Console.Clear();
                Console.WriteLine(Localizations.RussianLocalization[EnumCreateRecepietMenu.ErrorMetersNotCorrect]);
                Console.ReadKey();
            }
            else
            {
                //расчёт стоимости услуг
                _calculateCost.Calculate(newReceipt, previousReceipt);

                //создание нового элемента в БД
                _dbCRUD.Create(newReceipt);

                Console.Clear();
                Console.WriteLine(Localizations.RussianLocalization[EnumCreateRecepietMenu.RecepietAdd]);
                Console.ReadKey();
            }
        }
    }
}
