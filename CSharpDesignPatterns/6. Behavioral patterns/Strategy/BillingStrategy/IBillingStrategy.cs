namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    public interface IBillingStrategy
    {
        double GetPrice(double originalPrice);
    }
}