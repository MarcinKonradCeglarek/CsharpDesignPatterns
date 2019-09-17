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
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            throw new NotImplementedException();
        }
    }
}