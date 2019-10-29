namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class FacebookUser
    {
        public FacebookUser(string name, IEnumerable<string> friends)
        {
            throw new NotImplementedException();
        }

        public ImmutableList<string> Friends { get; private set; }

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
}