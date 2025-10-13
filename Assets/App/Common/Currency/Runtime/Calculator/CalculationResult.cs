namespace App.Common.Currency.Runtime.Calculator
{
    public struct CalculationResult
    {
        public readonly long Value;
        public readonly CalculationErrors Result;

        public CalculationResult(long value, CalculationErrors result)
        {
            Value = value;
            Result = result;
        }
    }
}