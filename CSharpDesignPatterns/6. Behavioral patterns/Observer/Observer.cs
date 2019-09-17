namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;

    using CSharpDesignPatterns.Common.Model;
    using CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model;

    public class Observer : IObserver<PayLoad>
    {
        private readonly IDisplayer logger;

        public Observer(IDisplayer logger)
        {
            this.logger = logger;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(PayLoad payload)
        {
            this.logger.Display(payload.Message);
        }
    }
}