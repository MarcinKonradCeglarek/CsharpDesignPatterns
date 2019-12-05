namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;
    using System.Collections.Generic;

    public interface IReceivedMessagesHandler
    {
        void HandleReceivedMessage(string author, string message);
    }

    public interface IChatRoomClient
    {
        string Name { get; }
        void   SendMessageThroughMediator(string message);
    }

    public class ChatRoomMediator
    {
        private readonly IDictionary<Guid, Action<string, string>> clients =
            new Dictionary<Guid, Action<string, string>>();

        public void Register(Guid clientId, Action<string, string> callback)
        {
            this.clients.Add(clientId, callback);
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