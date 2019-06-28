namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

    using Castle.Core.Internal;

    using CSharpDesignPatterns.Common.Model;

    public class PayLoad
    {
        public PayLoad(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }

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

        public void OnNext(PayLoad value)
        {
            throw new NotImplementedException();
        }
    }
}