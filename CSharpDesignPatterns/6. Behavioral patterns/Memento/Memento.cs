namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class FacebookUser
    {
        public FacebookUser(string name, IEnumerable<string> friends)
        {
            throw new NotImplementedException();
        }

        public List<string> Friends { get; set; }

        public string Name { get; set; }

        public void AddFriend(string friendName)
        {
            throw new NotImplementedException();
        }

        public void ChangeName(string newName)
        {
            throw new NotImplementedException();
        }

        public FacebookUserMemento CreateMemento()
        {
            throw new NotImplementedException();
        }

        public void Restore(FacebookUserMemento memento)
        {
            throw new NotImplementedException();
        }
    }

    public class FacebookUserMemento
    {
        public readonly IEnumerable<string> Friends;
        public readonly string              Name;

        public FacebookUserMemento(string name, IEnumerable<string> friends)
        {
            this.Name    = name;
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