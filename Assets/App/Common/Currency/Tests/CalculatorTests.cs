using App.Common.Currency.Runtime.Calculator;
using NUnit.Framework;

namespace App.Common.Currency.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void CalculatorAddTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Add(10, 15);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.Success);
            Assert.AreEqual(25, calculationResult.Value);
        }
        
        [Test]
        public void CalculatorAddOverflowTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Add(long.MaxValue, 15);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.Overflow);
        }
        
        [Test]
        public void CalculatorAddBelowZeroTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Add(10, -15);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.ValueBelowZero);
        }
        
        [Test]
        public void CalculatorAddBiggerThanMaxTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Add(100, 15, 110);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.BiggerThanMax);
            Assert.AreEqual(110, calculationResult.Value);
        }
        
        [Test]
        public void CalculatorSubtractTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Subtract(20, 15);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.Success);
            Assert.AreEqual(5, calculationResult.Value);
        }
        
        [Test]
        public void CalculatorSubtractCurrencyNotEnoughTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Subtract(0, 100);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.CurrencyNotEnough);
        }
        
        [Test]
        public void CalculatorSubtractBelowZeroTest()
        {
            CurrencyCalculator currencyCalculator = new CurrencyCalculator();
            var calculationResult = currencyCalculator.Subtract(10, -15);
            Assert.IsTrue(calculationResult.Result == CalculationErrors.ValueBelowZero);
        }

    }
}