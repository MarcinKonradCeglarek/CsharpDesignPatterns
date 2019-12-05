namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class MediatorTests
    {
        private static readonly Fixture Fixture = new Fixture();

        [Test]
        public void ProperlyForwardsOneMessage()
        {
            var message      = "Hi Alice!";
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob   = new ChatClient("Bob",   mediator, bobDisplay.Object);
            var alice = new ChatClient("Alice", mediator, aliceDisplay.Object);

            bob.SendMessageThroughMediator(message);

            aliceDisplay.Verify(d => d.HandleReceivedMessage(bob.Name,         message), Times.Once);
            bobDisplay.Verify(d => d.HandleReceivedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void ProperlyCountsOneMessage()
        {
            var message      = "Hi Counter!";
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var alice   = new ChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new ChatMessageCounter(mediator);

            alice.SendMessageThroughMediator(message);

            Assert.AreEqual(1, counter.Counter);
        }

        [Test]
        public void ProperlyCountsMultipleMessagesFromOneSender()
        {
            var messages     = Fixture.CreateMany<string>().ToList();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var alice   = new ChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new ChatMessageCounter(mediator);

            foreach (var message in messages)
            {
                alice.SendMessageThroughMediator(message);
            }

            Assert.AreEqual(messages.Count, counter.Counter);
        }

        [Test]
        public void ProperlyForwardsMultipleMessagesFromOneSender()
        {
            // Arrange
            var messages     = Fixture.CreateMany<string>().ToList();
            var bobDisplay   = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob   = new ChatClient("Bob",   mediator, bobDisplay.Object);
            var alice = new ChatClient("Alice", mediator, aliceDisplay.Object);

            // Act
            foreach (var message in messages)
            {
                alice.SendMessageThroughMediator(message);
            }

            // Assert
            aliceDisplay.Verify(m => m.HandleReceivedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            foreach (var message in messages)
            {
                bobDisplay.Verify(m => m.HandleReceivedMessage("Alice", message), Times.Once);
            }
        }

        [Test]
        public void ProperlyForwardsAndCountsMultipleMessagesFromMultipleSenders()
        {
            // Arrange
            var bobsMessages  = Fixture.CreateMany<string>().ToList();
            var aliceMessages = Fixture.CreateMany<string>().ToList();
            var bobDisplay    = new Mock<IReceivedMessagesHandler>();
            var aliceDisplay  = new Mock<IReceivedMessagesHandler>();

            var mediator = new ChatRoomMediator();

            var bob     = new ChatClient("Bob",   mediator, bobDisplay.Object);
            var alice   = new ChatClient("Alice", mediator, aliceDisplay.Object);
            var counter = new ChatMessageCounter(mediator);

            // Act
            foreach (var aliceMessage in aliceMessages)
            {
                alice.SendMessageThroughMediator(aliceMessage);
            }

            foreach (var bobsMessage in bobsMessages)
            {
                bob.SendMessageThroughMediator(bobsMessage);
            }

            // Assert
            foreach (var aliceMessage in aliceMessages)
            {
                bobDisplay.Verify(m => m.HandleReceivedMessage("Alice", aliceMessage), Times.Once);
            }

            foreach (var bobsMessage in bobsMessages)
            {
                aliceDisplay.Verify(m => m.HandleReceivedMessage("Bob", bobsMessage), Times.Once);
            }

            Assert.AreEqual(bobsMessages.Count + aliceMessages.Count, counter.Counter);
        }
    }
}