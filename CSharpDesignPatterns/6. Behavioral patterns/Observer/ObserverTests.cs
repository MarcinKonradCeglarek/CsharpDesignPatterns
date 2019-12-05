namespace CSharpDesignPatterns._6._Behavioral_patterns.Observer
{
    using System;

    using CSharpDesignPatterns.Common.Model;
    using CSharpDesignPatterns._6._Behavioral_patterns.Observer.Model;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ObserverTests
    {
        [Test]
        public void Subscribe2AndDispose_BothVisibleInSubject()
        {
            var sut  = new Subject();
            var mock = new Mock<IDisplayer>();

            var observer1 = new Observer(mock.Object);
            var observer2 = new Observer(mock.Object);

            using (sut.Subscribe(observer1))
            {
                using (sut.Subscribe(observer2))
                {
                    Assert.AreEqual(2, sut.Observers.Count);
                    CollectionAssert.AreEquivalent(new[] { observer1, observer2 }, sut.Observers);
                }
            }

            Assert.AreEqual(0, sut.Observers.Count);
        }

        [Test]
        public void Subscribe2Unsubscribe1AndRaiseEvent_ValidOneRemains()
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

        [Test]
        public void Subscribe2Unsubscribe1RaiseEvent_MessageIsOnlyForwardedToSubscribedObserver()
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

        [Test]
        public void SubscribeTwoObserversAndRaiseEvent_EventIsDisplayedTwice()
        {
            const string Message = "One Ring to rule them all";
            var          sut     = new Subject();
            var          mock    = new Mock<IDisplayer>();

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
    }
}