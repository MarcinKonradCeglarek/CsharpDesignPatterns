namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;

    public class ChatClient : IChatRoomClient
    {
        private readonly ChatRoomMediator mediator;

        public ChatClient(string name, ChatRoomMediator mediator, IReceivedMessagesHandler receivedMessagesHandler)
        {
            this.Name     = name;
            this.mediator = mediator;
            this.mediator.Register(this.Id, receivedMessagesHandler.HandleReceivedMessage);
        }

        public Guid   Id   { get; } = Guid.NewGuid();
        public string Name { get; }

        public void SendMessageThroughMediator(string message)
        {
            this.mediator.SendMessage(this.Id, this.Name, message);
        }
    }
}