using System;
using System.Linq;
using Spectre.Console;
using CommunalCalculator.CodeBase.Localization;
using CommunalCalculator.CodeBase.DBScripts.DBOperations;
using CommunalCalculator.CodeBase.Enums;

namespace CommunalCalculator.CodeBase.UserInterface
{
    public class ViewReceiptsMenu
    {
        private IDBOperations _dbOperations;
        private Table _receiptsTable;

        public ViewReceiptsMenu()
        {
            _dbOperations = new DBOperations();
            _receiptsTable = new Table();
        }

        public void ShowReceiptsTable()
        {
            Console.Clear();

            if (_dbOperations.GetReceiptsDB().Receipts.Count() > 0)
            {
                if (_receiptsTable.Columns.Count == 0)
                {
                    CreateColumns();
                }

                FillTable();
                AnsiConsole.Write(_receiptsTable);
            }
            else
            {
                Console.WriteLine(Localizations.RussianLocalization[EnumViewReceipts.NoReceipts]);
            }

            Console.ReadKey();
        }

        private void CreateColumns()
        {
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.Id]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.ColdWater]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.HotWaterValue]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.HotWaterEnergy]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.ElectricityStandart]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.ElectricityDay]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.ElectricityNight]);
            _receiptsTable.AddColumn(Localizations.RussianLocalization[EnumViewReceipts.Total]);
        }

        private void FillTable()
        {
            var rowsCount = _receiptsTable.Rows.Count;

            for (int i = 0; i < rowsCount; i++)
            {
                _receiptsTable.RemoveRow(0);
            }

            foreach (var item in _dbOperations.GetReceiptsDB().Receipts)
            {
                _receiptsTable.AddRow(
                    item.Id.ToString(),
                    item.ColdWater.ToString(),
                    item.HotWaterAmount.ToString(),
                    item.HotWaterEnergy.ToString(),
                    item.ElectricityStandart.ToString(),
                    item.ElectricityDay.ToString(),
                    item.ElectricityNight.ToString(),
                    "----"
                );

                _receiptsTable.AddRow(
                    "----",
                    item.ColdWaterCost.ToString(),
                    item.HotWaterAmountCost.ToString(),
                    item.HotWaterEnergyCost.ToString(),
                    item.ElectricityStandartDayCost.ToString(),
                    item.ElectricityDayCost.ToString(),
                    item.ElectricityNightCost.ToString(),
                    item.FullCost.ToString()
                );

                _receiptsTable.AddRow(
                    "----",
                    "----",
                    "----",
                    "----",
                    "----",
                    "----",
                    "----",
                    "----"
                );
            }
        }
    }
}
