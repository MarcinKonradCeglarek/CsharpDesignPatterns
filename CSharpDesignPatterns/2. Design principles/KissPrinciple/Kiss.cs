namespace CSharpDesignPatterns._2._Design_principles.KissPrinciple
{
    using CSharpDesignPatterns._2._Design_principles.KissPrinciple.Helpers;

    internal class Kiss
    {
        /*
         * Keep it simple, stupid
         *
         * "most systems work best if they are kept simple rather than made complicated; therefore,
         *  simplicity should be a key goal in design, and unnecessary complexity should be avoided"
         *
         * Good examples: over-engineering of a solution
         */

        public static string MvcDisplay()
        {
            var controller = new Controller(new Model());
            return controller.CreateMessage();
        }

        public static string SimpleDisplay()
        {
            return Constants.HelloWorld;
        }
    }
}