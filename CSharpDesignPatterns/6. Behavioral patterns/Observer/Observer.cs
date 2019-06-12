namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

    using Castle.Core.Internal;

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
            this.Observers.ForEach(o => o.OnNext(new PayLoad(message)));
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            return new Unsubscriber(this.Observers, observer);
        }
    }

    public class Unsubscriber : IDisposable
    {
        private readonly IObserver<PayLoad> observer;
        private readonly IList<IObserver<PayLoad>> observers;

        public Unsubscriber(IList<IObserver<PayLoad>> observers, IObserver<PayLoad> observer)
        {
            this.observers = observers;
            this.observer  = observer;
            this.observers.Add(observer);
        }

        public void Dispose()
        {
            this.observers.Remove(this.observer);
        }
    }

    public class Observer : IObserver<PayLoad>
    {
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