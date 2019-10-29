namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;

    public class ChatClient : IChatRoomClient
    {
        private readonly ChatRoomMediator mediator;

        public ChatClient(string name, ChatRoomMediator mediator, IReceivedMessagesHandler receivedMessagesHandler)
        {
            throw new NotImplementedException();
        }

        public Guid   Id   { get; } = Guid.NewGuid();
        public string Name { get; }

        public void SendMessageThroughMediator(string message)
        {
            throw new NotImplementedException();
        }
    }
}