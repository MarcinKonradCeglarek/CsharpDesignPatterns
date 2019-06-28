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
        void   SendMessageThroughMediator(string message);
    }

    public class ChatClient : IChatRoomClient
    {
        public ChatClient(string name, ChatRoomMediator mediator, IReceivedMessagesHandler receivedMessagesHandler)
        {
            /*
             * Register with mediator (so that mediator knows who dispatch messages to)
             */
            throw new NotImplementedException();
        }

        public string Name { get; }

        public Guid Id { get; } = Guid.NewGuid(); 

        public void SendMessageThroughMediator(string message)
        {
            throw new NotImplementedException();
        }

        private void ReceiveMessageViaMediator(string author, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class ChatMessageCounter : IChatRoomClient
    {
        public ChatMessageCounter(ChatRoomMediator mediator)
        {
            throw new NotImplementedException();
            /*
             * Register with mediator (so that mediator knows who dispatch messages to)
             */
        }

        public int Counter { get; private set; }

        public string Name { get; } = $"Counter_{Guid.NewGuid()}";



        public void SendMessageThroughMediator(string message)
        {
            throw new NotSupportedException();
        }

        private void ReceiveMessageViaMediator(string author, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class ChatRoomMediator
    {
        public IDictionary<Guid, Action<string, string>> Clients { get; } =
            new Dictionary<Guid, Action<string, string>>();

        public void Register(Guid clientId, Action<string, string> callback)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Guid clientId, string author, string message)
        {
            /*
             * Check if client is on mediator's clients list
             *   if yes, broadcast messages to all other clients
             */
        }
    }
}