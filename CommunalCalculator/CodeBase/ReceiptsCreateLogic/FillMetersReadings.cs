using System;
using System.Collections.Generic;
using CommunalCalculator.CodeBase.DBScripts.Models;
using CommunalCalculator.CodeBase.Enums;
using CommunalCalculator.CodeBase.Localization;
using CommunalCalculator.CodeBase.BackgroundInformation;
using CommunalCalculator.CodeBase.CalculationAlgorithms.StandartHotWaterEnergyAlgorithm;

namespace CommunalCalculator.CodeBase.ReceiptsCreateLogic
{
    public class FillMetersReadings
    {
        private IndicatorsStandart _indicatorsStandart;
        private IStandartHotWaterEnergyAlgorithm _hotWaterEnergyAlgorithm;
        private HotWaterEnergyStandart _hotWaterEnergyStandart;

        public FillMetersReadings()
        {
            _indicatorsStandart = new IndicatorsStandart();
            _hotWaterEnergyAlgorithm = new StandartHotWaterEnergyAlgorithm();
            _hotWaterEnergyStandart = new HotWaterEnergyStandart();
        }

        public void Fill(Receipt newReceipt, Receipt oldReceipt, Dictionary<Enum, bool> metersCheck)
        {
            if (metersCheck[EnumMetersTypes.ColdWaterMeter] == true)
            {
                newReceipt.ColdWater = SpecifyMeter(EnumMetersTypes.ColdWaterMeter);
            }
            else
            {
                newReceipt.ColdWater = _indicatorsStandart.ColdWater * newReceipt.Residents + oldReceipt.ColdWater;
            }

            if (metersCheck[EnumMetersTypes.HotWaterMeter] == true)
            {
                newReceipt.HotWaterAmount = SpecifyMeter(EnumMetersTypes.HotWaterMeter);
                newReceipt.HotWaterEnergy = _hotWaterEnergyAlgorithm.Calculate(newReceipt.HotWaterAmount, _hotWaterEnergyStandart.HotWaterEnergy);
            }
            else
            {
                newReceipt.HotWaterAmount = _indicatorsStandart.HotWaterAmount * newReceipt.Residents + oldReceipt.ColdWater;
                newReceipt.HotWaterEnergy = _indicatorsStandart.HotWaterEnergy * newReceipt.Residents + oldReceipt.HotWaterEnergy;
            }

            if (metersCheck[EnumMetersTypes.ElectricityMeter] == true)
            {
                newReceipt.ElectricityDay = SpecifyMeter(EnumMetersTypes.ElectricityDayMeter);
                newReceipt.ElectricityNight = SpecifyMeter(EnumMetersTypes.ElectricityNightMeter);
            }
            else
            {
                newReceipt.ElectricityDay = oldReceipt.ElectricityDay;
                newReceipt.ElectricityNight = oldReceipt.ElectricityNight;

                newReceipt.ElectricityStandart = _indicatorsStandart.Electricity * newReceipt.Residents;
            }
        }

        private float SpecifyMeter(Enum meterType)
        {
            if (Enum.TryParse<EnumMetersTypes>(meterType.ToString(), out EnumMetersTypes result))
            {
                Console.Clear();
                Console.WriteLine(Localizations.RussianLocalization[EnumCreateRecepietMenu.SpecifyMetersReadings] + "\n");
                Console.Write(Localizations.RussianLocalization[result] + ": ");

                var input = Console.ReadLine();
                if (float.TryParse(input, out float value))
                {
                    return value;
                }
            }

            return 0.0f;
        }
    }
}
