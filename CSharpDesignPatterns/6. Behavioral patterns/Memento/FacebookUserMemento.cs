namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System.Collections.Immutable;

    public class FacebookUserMemento
    {
        public readonly ImmutableList<string> Friends;
        public readonly string                Name;

        public FacebookUserMemento(string name, ImmutableList<string> friends)
        {
            this.Name    = name;
            this.Friends = friends;
        }
    }
}