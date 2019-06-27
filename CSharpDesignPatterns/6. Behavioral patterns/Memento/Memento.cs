namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Generic;

    public class FacebookUser
    {
        public FacebookUser(string name, IEnumerable<string> friends)
        {
            this.Name = name;
            this.Friends = new List<string>(friends);
        }

        public string       Name    { get; set; }
        public List<string> Friends { get; set; }

        public void Restore(FacebookUserMemento memento)
        {
            this.Name    = memento.Name;
            this.Friends = new List<string>(memento.Friends);
        }

        public FacebookUserMemento CreateMemento()
        {
            return new FacebookUserMemento(this.Name, this.Friends);
        }

        public void ChangeName(string newName)
        {
            throw new NotImplementedException();
        }

        public void AddFriend(string friendName)
        {
            throw new NotImplementedException();
        }
    }

    public class FacebookUserMemento
    {
        public readonly string Name;
        public readonly List<string> Friends;

        public FacebookUserMemento(string name, List<string> friends)
        {
            this.Name = name;
            this.Friends = friends;
        }
    }

    public class CareTaker
    {
        public CareTaker(FacebookUser user, IEnumerable<Action<FacebookUser>> actions)
        {
            throw new NotImplementedException();
        }
    }
}
