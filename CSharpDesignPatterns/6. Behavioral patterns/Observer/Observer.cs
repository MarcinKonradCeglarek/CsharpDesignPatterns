namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;
    using System.Collections.Generic;

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
            foreach (var observer in this.Observers)
            {
                observer.OnNext(new PayLoad(message));
            }
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            this.Observers.Add(observer);
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
        }

        public void Dispose()
        {
            this.observers.Remove(this.observer);
        }
    }

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