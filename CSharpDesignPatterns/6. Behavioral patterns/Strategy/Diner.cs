namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Diner
    {
        public Diner(IBillingStrategy strategy)
        {
            throw new NotImplementedException();
        }

        public IBillingStrategy Strategy { get; set; }

        public void Order(double price, int quantity)
        {
            throw new NotImplementedException();
        }

        public double GetTotalAmount()
        {
            throw new NotImplementedException();
        }
    }
}