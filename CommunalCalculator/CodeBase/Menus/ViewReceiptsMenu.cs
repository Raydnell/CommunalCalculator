using System;
using System.Linq;
using Spectre.Console;

using CommunalCalculator.CodeBase.DBScripts.CRUD;

namespace CommunalCalculator.CodeBase.UserInterface
{
    public class ViewReceiptsMenu
    {
        private ICRUD _indicationsCRUD;
        private Table _indicationsTable;

        public ViewReceiptsMenu()
        {
            _indicationsCRUD = new CRUDSQLite();
            _indicationsTable = new Table();
        }

        public void ShowIndications()
        {
            Console.Clear();

            if (_indicationsCRUD.GetReceiptsDB().Receipts.Count() > 0)
            {
                if (_indicationsTable.Columns.Count == 0)
                {
                    CreateColumns();
                }

                FillTable();
                AnsiConsole.Write(_indicationsTable);
            }
            else
            {
                Console.WriteLine("Нет квитанций");
            }

            Console.ReadKey();
        }

        private void CreateColumns()
        {
            _indicationsTable.AddColumn("Id");
            _indicationsTable.AddColumn("ХВС (м3/руб.)");
            _indicationsTable.AddColumn("ГВС вода (м3/руб.)");
            _indicationsTable.AddColumn("ГВС энергия (Гкал/руб.)");
            _indicationsTable.AddColumn("Электричество (без счётчика) (кВт.ч/руб.)");
            _indicationsTable.AddColumn("Элекстричество день (кВт.ч/руб.)");
            _indicationsTable.AddColumn("Элекстричество ночь (кВт.ч/руб.)");
            _indicationsTable.AddColumn("Жильцов / Итого");
        }

        private void FillTable()
        {
            var rowsCount = _indicationsTable.Rows.Count;

            for (int i = 0; i < rowsCount; i++)
            {
                _indicationsTable.RemoveRow(0);
            }

            foreach (var item in _indicationsCRUD.GetReceiptsDB().Receipts)
            {
                _indicationsTable.AddRow(
                    item.Id.ToString(),
                    item.ColdWater.ToString(),
                    item.HotWaterAmount.ToString(),
                    item.HotWaterEnergy.ToString(),
                    item.ElectricityStandart.ToString(),
                    item.ElectricityDay.ToString(),
                    item.ElectricityNight.ToString(),
                    item.Residents.ToString()
                );

                _indicationsTable.AddRow(
                    "----",
                    item.ColdWaterCost.ToString(),
                    item.HotWaterAmountCost.ToString(),
                    item.HotWaterEnergyCost.ToString(),
                    item.ElectricityStandartDayCost.ToString(),
                    item.ElectricityDayCost.ToString(),
                    item.ElectricityNightCost.ToString(),
                    item.FullCost.ToString()
                );

                _indicationsTable.AddRow(
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
