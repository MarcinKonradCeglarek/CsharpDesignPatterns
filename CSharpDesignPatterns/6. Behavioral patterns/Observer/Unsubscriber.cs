namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model;

    public class Unsubscriber : IDisposable
    {
        private readonly IList<IObserver<PayLoad>> observers;
        private readonly IObserver<PayLoad> observer;

        public Unsubscriber(IList<IObserver<PayLoad>> observers, IObserver<PayLoad> observer)
        {
            this.observers = observers;
            this.observer = observer;
            this.observers.Add(observer);
        }

        public void Dispose()
        {
            this.observers.Remove(this.observer);
        }
    }
}