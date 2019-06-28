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

        public int Counter { get; set; }

        public string Name { get; } = $"Counter_{Guid.NewGuid()}";

        public void ReceiveMessageViaMediator(string author, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessageThroughMediator(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class ChatRoomMediator
    {
        public ICollection<IChatRoomClient> Clients { get; } = new List<IChatRoomClient>();
            /*
             * Register client and it's callback function (used when sending him message)
             */

        public void SendMessage(IChatRoomClient client, string message)
        {
            /*
             * Check if client is on mediator's clients list
             *   if yes, broadcast messages to all other clients
             */
        }
    }
}