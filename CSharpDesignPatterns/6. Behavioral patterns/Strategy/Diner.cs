namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    public class Diner
    {
        private double total;

        public Diner(IBillingStrategy billingStrategy, ITippingStrategy tippingStrategy)
        {
            this.BillingStrategy = billingStrategy;
            this.TippingStrategy = tippingStrategy;
        }

        public IBillingStrategy BillingStrategy { get; set; }

        public ITippingStrategy TippingStrategy { get; set; }

        public void Order(double price)
        {
            var billAmount = this.BillingStrategy.GetPrice(price);
            var tipAmount  = this.TippingStrategy.GetTip(billAmount);
            this.total += billAmount + tipAmount;
        }

        public double GetTotalAmount()
        {
            return this.total;
        }
    }
}