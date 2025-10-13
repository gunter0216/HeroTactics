namespace App.Common.Currency.Runtime.Calculator
{
    public enum CalculationErrors
    {
        Success,
        Overflow,
        BiggerThanMax,
        ValueBelowZero,
        CurrencyNotEnough
    }
}