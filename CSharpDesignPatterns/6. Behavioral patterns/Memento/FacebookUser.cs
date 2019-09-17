namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class FacebookUser
    {
        public FacebookUser(string name, IEnumerable<string> friends)
        {
            this.Name = name;
            this.Friends = friends.ToImmutableList();
        }

        public ImmutableList<string> Friends { get; private set; }

        public string Name { get; set; }

        public void AddFriend(string friendName)
        {
            this.Friends = this.Friends.Add(friendName);
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        public FacebookUserMemento CreateMemento()
        {
            return new FacebookUserMemento(this.Name, this.Friends);
        }

        public void Restore(FacebookUserMemento memento)
        {
            this.Name = memento.Name;
            this.Friends = memento.Friends;
        }
    }
}