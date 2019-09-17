namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;

    using CSharpDesignPatterns.Common.Model;
    using CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model;

    public class Observer : IObserver<PayLoad>
    {
        public Observer(IDisplayer logger)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(PayLoad payload)
        {
            throw new NotImplementedException();
        }
    }
}