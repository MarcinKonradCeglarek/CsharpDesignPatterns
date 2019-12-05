namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    public class FlatTippingStrategy : ITippingStrategy
    {
        // 5$ per order
        public double GetTip(double originalPrice)
        {
            return 5;
        }
    }
}