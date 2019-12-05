namespace CSharpDesignPatterns._6._Behavioral_patterns.Mediator
{
    using System;

    public class ChatMessageCounter : IChatRoomClient
    {
        public ChatMessageCounter(ChatRoomMediator mediator)
        {
            throw new NotImplementedException();
        }

        public int    Counter { get; private set; }
        public Guid   Id      { get; } = Guid.NewGuid();
        public string Name    { get; } = $"Counter_{Guid.NewGuid()}";

        public void SendMessageThroughMediator(string message)
        {
            throw new NotImplementedException();
        }
    }
}