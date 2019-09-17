namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model;

    public class Subject : IObservable<PayLoad>
    {
        public IList<IObserver<PayLoad>> Observers { get; } = new List<IObserver<PayLoad>>();

        public void RaiseEvent(string message)
        {
            foreach (var observer in this.Observers)
            {
                observer.OnNext(new PayLoad(message));
            }
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            return new Unsubscriber(this.Observers, observer);
        }
    }
}