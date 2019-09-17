namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class MediatorTests
    {
        [Test]
        public void ProperlyForwardsOneMessage()
        {
            var message      = "Hi Alice";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new ChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new ChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new ChatMessageCounter(mediator);

            bob.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name,         message), Times.Once);
            bobDisplay.Verify(d => d.HandleReceivedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            Assert.AreEqual(1, counter.Counter);
        }

        [Test]
        public void ProperlyForwardsMultipleMessagesFromOneSender()
        {
            var message      = "Hi Alice";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new ChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new ChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new ChatMessageCounter(mediator);

            bob.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name,         message), Times.Exactly(3));
            bobDisplay.Verify(d => d.HandleReceivedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            Assert.AreEqual(3, counter.Counter);
        }

        [Test]
        public void ProperlyForwardsMultipleMessagesFromMultipleSenders()
        {
            var message      = "Hello there, General Kenobi!";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new ChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new ChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new ChatMessageCounter(mediator);

            bob.SendMessageThroughMediator(message);
            alice.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);
            alice.SendMessageThroughMediator(message);
            bob.SendMessageThroughMediator(message);
            alice.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name, message), Times.Exactly(3));
            bobDisplay.Verify(d => d.HandleReceivedMessage(alice.Name, message), Times.Exactly(3));
            Assert.AreEqual(6, counter.Counter);
        }
    }
}