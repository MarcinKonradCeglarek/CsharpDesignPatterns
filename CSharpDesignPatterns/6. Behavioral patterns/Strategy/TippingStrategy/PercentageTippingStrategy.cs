namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    public class PercentageTippingStrategy : ITippingStrategy
    {
        private readonly double percentage;

        public PercentageTippingStrategy(double percentage)
        {
            this.percentage = percentage;
        }

        public double GetTip(double originalPrice)
        {
            return originalPrice * this.percentage;
        }
    }
}