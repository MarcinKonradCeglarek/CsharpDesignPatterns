namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model;

    public class Unsubscriber : IDisposable
    {
        public Unsubscriber(IList<IObserver<PayLoad>> observers, IObserver<PayLoad> observer)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}