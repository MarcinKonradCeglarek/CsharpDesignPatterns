namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class MediatorTests
    {

        [Test]
        public void Mediator_2MediatedClients_ProperlySendsOneMessage()
        {
            var message      = "Hi Alice";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new HttpChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new HttpChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new MessageCounter(mediator);

            bob.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name,         message), Times.Once);
            bobDisplay.Verify(d => d.HandleReceivedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            Assert.AreEqual(1, counter.Counter);
        }

        [Ignore("")]
        [Test]
        public void Mediator_2MediatedClients_ProperlySendsMultipleMessages()
        {
            var message      = "Hi Alice";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new HttpChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new HttpChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new MessageCounter(mediator);

            bob.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name,         message), Times.Exactly(3));
            bobDisplay.Verify(d => d.HandleReceivedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            Assert.AreEqual(3, counter.Counter);
        }

        [Ignore("")]
        [Test]
        public void Mediator_2MediatedClients_ProperlySendsMultipleMessagesBackAndForth()
        {
            var message      = "Hello there, General Kenobi!";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new HttpChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new HttpChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new MessageCounter(mediator);

            bob.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);
            alice.SendMessageThroughMediator(message);
            alice.SendMessageThroughMediator(message);
            alice.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name, message), Times.Exactly(3));
            bobDisplay.Verify(d => d.HandleReceivedMessage(alice.Name, message), Times.Exactly(3));
            Assert.AreEqual(6, counter.Counter);
        }

    }
}