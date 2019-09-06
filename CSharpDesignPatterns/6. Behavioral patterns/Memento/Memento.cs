namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class FacebookUser
    {
        public FacebookUser(string name, IEnumerable<string> friends)
        {
            this.Name = name;
            this.Friends = friends.ToImmutableList();
        }

        public string       Name    { get; set; }
        public ImmutableList<string> Friends { get; set; }

        public void Restore(FacebookUserMemento memento)
        {
            this.Name    = memento.Name;
            this.Friends = memento.Friends.ToImmutableList();
        }

        public FacebookUserMemento CreateMemento()
        {
            return new FacebookUserMemento(this.Name, this.Friends);
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        public void AddFriend(string friendName)
        {
            this.Friends = this.Friends.Add(friendName);
        }
    }

    public class FacebookUserMemento
    {
        public readonly string Name;
        public readonly IEnumerable<string> Friends;

        public FacebookUserMemento(string name, IEnumerable<string> friends)
        {
            this.Name = name;
            this.Friends = friends;
        }
    }

    public class CareTaker
    {
        public CareTaker(FacebookUser user, IEnumerable<Action<FacebookUser>> actions)
        {
            var mememnto = user.CreateMemento();
            try
            {
                foreach (var action in actions)
                {
                    action(user);
                }
            }
            catch
            {
                user.Restore(mememnto);
            }
        }
    }
}
