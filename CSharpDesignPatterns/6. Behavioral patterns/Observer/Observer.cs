namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

    public class PayLoad
    {
        public string Message { get; set; }
    }

    public class Subject : IObservable<PayLoad>
    {
        public Subject()
        {
            throw new NotImplementedException();
        }

        public IList<IObserver<PayLoad>> Observers { get; set; }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            throw new NotImplementedException();
        }
    }

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

    public class Observer : IObserver<PayLoad>
    {
        public string Message { get; set; }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(PayLoad value)
        {
            throw new NotImplementedException();
        }
    }
}