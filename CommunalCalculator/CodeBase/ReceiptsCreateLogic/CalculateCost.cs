using System;
using CommunalCalculator.CodeBase.DBScripts.Models;
using CommunalCalculator.CodeBase.CalculationAlgorithms.RegulagCalculationAlgorithm;
using CommunalCalculator.CodeBase.BackgroundInformation;

namespace CommunalCalculator.CodeBase.ReceiptsCreateLogic
{
    public class CalculateCost
    {
        private IRegularCostCalculationAlgorithm _costAlgorithm;

        public CalculateCost()
        {
            _costAlgorithm = new RegularCostCalculationAlgorithm();
        }

        public void Calculate(Receipt newReceipt, Receipt oldReceipt)
        {
            newReceipt.ColdWaterCost = Math.Round(_costAlgorithm.Calculate(newReceipt.ColdWater - oldReceipt.ColdWater, CalculationsTariffs.ColdWater), 2);
            newReceipt.HotWaterAmountCost = Math.Round(_costAlgorithm.Calculate(newReceipt.HotWaterAmount - oldReceipt.HotWaterAmount, CalculationsTariffs.HotWaterAmount), 2);
            newReceipt.HotWaterEnergyCost = Math.Round(_costAlgorithm.Calculate(newReceipt.HotWaterEnergy - oldReceipt.HotWaterEnergy, CalculationsTariffs.HotWaterEnergy), 2);
            newReceipt.ElectricityDayCost = Math.Round(_costAlgorithm.Calculate(newReceipt.ElectricityDay - oldReceipt.ElectricityDay, CalculationsTariffs.ElectricityDay), 2);
            newReceipt.ElectricityNightCost = Math.Round(_costAlgorithm.Calculate(newReceipt.ElectricityNight - oldReceipt.ElectricityNight, CalculationsTariffs.ElecticityNight), 2);
            newReceipt.ElectricityStandartDayCost = Math.Round(_costAlgorithm.Calculate(newReceipt.ElectricityStandart, CalculationsTariffs.Electricity), 2);
            newReceipt.FullCost =
                Math.Round((newReceipt.ColdWaterCost +
                newReceipt.HotWaterAmountCost +
                newReceipt.HotWaterEnergyCost +
                newReceipt.ElectricityDayCost +
                newReceipt.ElectricityNightCost +
                newReceipt.ElectricityStandartDayCost), 2);
        }
    }
}
