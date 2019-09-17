namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;

    public class Diner
    {
        public Diner(IBillingStrategy billingStrategy, ITippingStrategy tippingStrategy)
        {
        }

        public IBillingStrategy BillingStrategy { get; set; }

        public ITippingStrategy TippingStrategy { get; set; }

        public void Order(double price)
        {
            throw new NotImplementedException();
        }

        public double GetTotalAmount()
        {
            throw new NotImplementedException();
        }
    }
}