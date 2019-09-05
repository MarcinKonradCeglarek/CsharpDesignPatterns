namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IReceivedMessagesHandler
    {
        void HandleReceivedMessage(string author, string message);
    }

    public interface IChatRoomClient
    {
        string Name { get; }
        void   SendMessageThroughMediator(string message);
    }

    public class ChatClient : IChatRoomClient
    {
        private readonly ChatRoomMediator         mediator;
        private readonly IReceivedMessagesHandler receivedMessagesHandler;

        public ChatClient(string name, ChatRoomMediator mediator, IReceivedMessagesHandler receivedMessagesHandler)
        {
            /*
             * Register with mediator (so that mediator knows who dispatch messages to)
             */
            this.mediator                = mediator;
            this.receivedMessagesHandler = receivedMessagesHandler;
            this.Name                    = name;

            this.mediator.Register(this.Id, this.ReceiveMessageViaMediator);
        }

        public Guid   Id   { get; } = Guid.NewGuid();
        public string Name { get; }

        public void SendMessageThroughMediator(string message)
        {
            this.mediator.SendMessage(this.Id, this.Name, message);
        }

        private void ReceiveMessageViaMediator(string author, string message)
        {
            this.receivedMessagesHandler.HandleReceivedMessage(author, message);
        }
    }

    public class ChatMessageCounter : IChatRoomClient
    {
        public ChatMessageCounter(ChatRoomMediator mediator)
        {
            /*
             * Register with mediator (so that mediator knows who dispatch messages to)
             */
            mediator.Register(this.Id, this.ReceiveMessageViaMediator);
        }

        public int    Counter { get; private set; }
        public Guid   Id      { get; } = Guid.NewGuid();
        public string Name    { get; } = $"Counter_{Guid.NewGuid()}";

        public void SendMessageThroughMediator(string message)
        {
            throw new NotSupportedException();
        }

        private void ReceiveMessageViaMediator(string author, string message)
        {
            this.Counter++;
        }
    }

    public class ChatRoomMediator
    {
        private readonly IDictionary<Guid, Action<string, string>> clients =
            new Dictionary<Guid, Action<string, string>>();

        public void Register(Guid clientId, Action<string, string> callback)
        {
            if (!this.clients.ContainsKey(clientId))
            {
                this.clients.Add(clientId, callback);
            }
        }

        public void SendMessage(Guid clientId, string author, string message)
        {
            /*
             * Check if client is on mediator's clients list
             *   if yes, broadcast messages to all other clients
             */
            if (this.clients.ContainsKey(clientId))
            {
                foreach (var client in this.clients.Where(c => c.Key != clientId))
                {
                    client.Value(author, message);
                }
            }
        }
    }
}