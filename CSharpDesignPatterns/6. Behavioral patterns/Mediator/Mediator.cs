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

    public class ChatClient : IChatRoomClient
    {
        public ChatClient(string name, ChatRoomMediator mediator, IReceivedMessagesHandler receivedMessagesHandler)
        {
            throw new NotImplementedException();
            /*
             * Register with mediator (so that mediator knows who dispatch messages to)
             */
        }

        public string Name { get; }

        public void ReceiveMessageViaMediator(string author, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessageThroughMediator(string message)
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

        public void ReceiveMessageViaMediator(string author, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessageThroughMediator(string message)
        {
            throw new NotSupportedException();
        }
    }

    public class ChatRoomMediator
    {
        public IDictionary<IChatRoomClient, Action<string, string>> Clients { get; } =
            new Dictionary<IChatRoomClient, Action<string, string>>();

        public void Register(IChatRoomClient client, Action<string, string> callback)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(IChatRoomClient client, string message)
        {
            /*
             * Check if client is on mediator's clients list
             *   if yes, broadcast messages to all other clients
             */
        }
    }
}