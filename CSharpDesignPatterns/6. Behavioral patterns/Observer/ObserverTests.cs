﻿namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ObserverTests
    {
        [Test]
        public void Subscribe2AndDispose_BothVisibleInSubject()
        {
            var sut = new Subject();
            var mock = new Mock<IDisplayer>();

            var observer1 = new Observer(mock.Object);
            var observer2 = new Observer(mock.Object);

            using (sut.Subscribe(observer1))
            {
                using (sut.Subscribe(observer2))
                {
                    Assert.AreEqual(2,         sut.Observers.Count);
                    Assert.AreEqual(observer1, sut.Observers[0]);
                    Assert.AreEqual(observer2, sut.Observers[1]);
                }
            }

            Assert.AreEqual(0, sut.Observers.Count);
        }

        [Test]
        public void SubscribeTwoObserversAndDisplayEventTwice()
        {
            const string Message = "One Ring to rule them all";
            var sut  = new Subject();
            var mock = new Mock<IDisplayer>();

            var observer1 = new Observer(mock.Object);
            var observer2 = new Observer(mock.Object);

            using (sut.Subscribe(observer1))
            {
                using (sut.Subscribe(observer2))
                {
                    sut.RaiseEvent(Message);
                }
            }

            mock.Verify(m => m.Display(Message), Times.Exactly(2));
        }

        [Ignore("")]
        [Test]
        public void Subscribe2Unsubscribe1_ValidOneRemains()
        {
            const string Message = "TestMessage";
            var          sut     = new Subject();

            var observer1 = new Mock<IObserver<PayLoad>>();
            var observer2 = new Mock<IObserver<PayLoad>>();

            using (sut.Subscribe(observer1.Object))
            {
                using (sut.Subscribe(observer2.Object))
                {
                    sut.RaiseEvent(Message);
                }
            }

            observer1.Verify(o => o.OnNext(It.Is<PayLoad>(p => p.Message == Message)), Times.Once);
            observer2.Verify(o => o.OnNext(It.Is<PayLoad>(p => p.Message == Message)), Times.Once);
        }

        [Ignore("")]
        [Test]
        public void Subscribe2Unsubscribe1SendMessage_MessageIsOnlyForwardedToSubscribedObserver()
        {
            const string Message = "TestMessage";
            var          sut     = new Subject();

            var observer1 = new Mock<IObserver<PayLoad>>();
            var observer2 = new Mock<IObserver<PayLoad>>();

            using (sut.Subscribe(observer1.Object))
            {
                using (sut.Subscribe(observer2.Object))
                {
                }

                sut.RaiseEvent(Message);
            }

            observer1.Verify(o => o.OnNext(It.Is<PayLoad>(p => p.Message == Message)), Times.Once);
            observer2.Verify(o => o.OnNext(It.Is<PayLoad>(p => p.Message == Message)), Times.Never);
        }
    }
}