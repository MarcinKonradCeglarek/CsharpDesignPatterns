namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System.Collections.Immutable;

    public class FacebookUserMemento
    {
        public readonly List<string> Friends;
        public readonly string       Name;

        public FacebookUserMemento(string name, List<string> friends)
        {
            this.Friends = friends;
            this.Name    = name;
        }
    }
}