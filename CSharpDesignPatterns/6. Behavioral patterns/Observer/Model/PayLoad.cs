namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model
{
    public class PayLoad
    {
        public PayLoad(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}