namespace Phase5DataLibrary.Helpers
{
    public static class MathExtensions
    {
        public static double ArmorUpgrades(this double originalValue, double improveBy)
        {
            double firstValue = 1 - originalValue;
            double secondValue = 1 + improveBy;
            double subs = firstValue / secondValue;
            double output = 1 - subs;
            return output;
        }
    }
}