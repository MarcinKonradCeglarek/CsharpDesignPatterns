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
        private readonly IMessageDisplayer displayer;

        public HttpChatClient(string name, ChatRoomMediator mediator, IMessageDisplayer displayer)
        {
            this.displayer = displayer;
            this.Name      = $"HTTP://{name}";
            this.Mediator  = mediator;
            this.Mediator.Clients.Add(this);
        }

        public  string           Name     { get; }
        private ChatRoomMediator Mediator { get; }

        public void ReceiveMessage(string author, string message)
        {
            this.displayer.Display(author, message);
        }

        public void SendMessage(string message)
        {
            this.Mediator.SendMessage(this, message);
        }
    }

    public class MessageCounter : IChatRoomClient
    {
        public MessageCounter(ChatRoomMediator mediator)
        {
            this.Mediator = mediator;
            this.Mediator.Clients.Add(this);
        }

        public int Counter { get; private set; }

        public ChatRoomMediator Mediator { get; set; }
        public string           Name     { get; }

        public void ReceiveMessage(string author, string message)
        {
            this.Counter++;
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
            if (!this.Clients.Contains(client))
            {
                throw new InvalidOperationException();
            }

            this.Clients.Where(c => c != client).ForEach(c => c.ReceiveMessage(client.Name, message));
        }
    }
}