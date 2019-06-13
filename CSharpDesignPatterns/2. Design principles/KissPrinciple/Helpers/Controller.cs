namespace CSharpDesignPatterns._2._Design_principles.KissPrinciple.Helpers
{
    internal class Controller
    {
        private readonly Model model;

        public Controller(Model model)
        {
            this.model = model;
        }

        public string CreateMessage()
        {
            var charray = this.model.Message.GetObject();
            var display = View.Display(charray);
            return display;
        }
    }
}