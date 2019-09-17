namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    public class Diner
    {
        private double totalAmount = 0;

        public Diner(IBillingStrategy billingStrategy, ITippingStrategy tippingStrategy)
        {
            this.BillingStrategy = billingStrategy;
            this.TippingStrategy = tippingStrategy;
        }

        public IBillingStrategy BillingStrategy { get; set; }

        public ITippingStrategy TippingStrategy { get; set; }

        public void Order(double price)
        {
            var priceAfterBilling = this.BillingStrategy.GetPrice(price);
            this.totalAmount += priceAfterBilling + this.TippingStrategy.GetTip(priceAfterBilling);
        }

        public double GetTotalAmount()
        {
            return this.totalAmount;
        }
    }
}