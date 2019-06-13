namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Core.Internal;

    public interface IReceivedMessagesHandler
    {
        void HandleReceivedMessage(string author, string message);
    }

    public interface IChatRoomClient
    {
        string Name { get; }
        void   ReceiveMessageViaMediator(string  author, string message);
        void   SendMessageThroughMediator(string message);
    }

    public class HttpChatClient : IChatRoomClient
    {
        private readonly ChatRoomMediator         mediator;
        private readonly IReceivedMessagesHandler receivedMessagesHandler;

        public HttpChatClient(string name, ChatRoomMediator mediator, IReceivedMessagesHandler receivedMessagesHandler)
        {
            this.Name                    = name;
            this.mediator                = mediator;
            this.receivedMessagesHandler = receivedMessagesHandler;
            this.mediator.Clients.Add(this);
        }

        public string Name { get; }

        public void ReceiveMessageViaMediator(string author, string message)
        {
            this.receivedMessagesHandler.HandleReceivedMessage(author, message);
        }

        public void SendMessageThroughMediator(string message)
        {
            this.mediator.SendMessage(this, message);
        }
    }

    public class MessageCounter : IChatRoomClient
    {
        private readonly ChatRoomMediator mediator;

        public MessageCounter(ChatRoomMediator mediator)
        {
            this.mediator = mediator;
            this.mediator.Clients.Add(this);
        }

        public int Counter { get; set; }

        public string Name { get; } = $"Counter_{Guid.NewGuid()}";

        public void ReceiveMessageViaMediator(string author, string message)
        {
            this.Counter++;
        }

        public void SendMessageThroughMediator(string message)
        {
            throw new InvalidOperationException();
        }
    }

    public class ChatRoomMediator
    {
        public ICollection<IChatRoomClient> Clients { get; } = new List<IChatRoomClient>();

        public void SendMessage(IChatRoomClient client, string message)
        {
            if (this.Clients.Contains(client))
            {
                this.Clients.Where(c => c != client).ForEach(c => c.ReceiveMessageViaMediator(client.Name, message));
            }
        }
    }
}