namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Core.Internal;

    public interface IMessageDisplayer
    {
        void Display(string author, string message);
    }

    public interface IChatRoomClient
    {
        string Name { get; }
        void   ReceiveMessage(string author, string message);
        void   SendMessage(string    message);
    }

    public class HttpChatClient : IChatRoomClient
    {
        public HttpChatClient(string name, ChatRoomMediator mediator, IMessageDisplayer displayer)
        {
            throw new NotImplementedException();
        }

        public  string           Name     { get; }

        public void ReceiveMessage(string author, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class MessageCounter : IChatRoomClient
    {
        public MessageCounter(ChatRoomMediator mediator)
        {
            throw new NotImplementedException();
        }

        public string           Name     { get; }
        public int Counter { get; set; }

        public void ReceiveMessage(string author, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }

    // Mediates the common tasks
    public class ChatRoomMediator
    {
        public ICollection<IChatRoomClient> Clients { get; } = new List<IChatRoomClient>();

        public void SendMessage(IChatRoomClient client, string message)
        {
            throw new NotImplementedException();
        }
    }
}