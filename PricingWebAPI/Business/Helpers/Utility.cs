namespace Business.Helpers
{
    public static class Utility
    {
        public static decimal GetRebatePrice(int totalPrice, decimal rebate)
        {
            decimal rebatePrice = totalPrice - (totalPrice * rebate / 100);
            return rebatePrice;

        }
        public static string ToCurrencyString(this decimal value)
        {
            return value < 1 ? $"{(int)(value * 100)}p" : $"{value:C}";
        }

    }
}
