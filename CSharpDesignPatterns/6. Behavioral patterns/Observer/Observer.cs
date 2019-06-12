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
            this.Observers = new List<IObserver<PayLoad>>();
        }

        public IList<IObserver<PayLoad>> Observers { get; set; }

        public void SendMessage(string message)
        {
            foreach (var observer in this.Observers)
            {
                observer.OnNext(new PayLoad { Message = message });
            }
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            if (!this.Observers.Contains(observer))
            {
                this.Observers.Add(observer);
            }

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
            if (this.observer != null && this.observers.Contains(this.observer))
            {
                this.observers.Remove(this.observer);
            }
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
            this.Message = value.Message;
        }

        public IDisposable Register(Subject subject)
        {
            return subject.Subscribe(this);
        }
    }
}