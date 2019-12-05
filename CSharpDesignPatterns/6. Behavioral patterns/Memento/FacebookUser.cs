namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Generic;

    public class FacebookUser
    {
        public FacebookUser(string name, IEnumerable<string> friends)
        {
            throw new NotImplementedException();
        }

        public List<string> Friends { get; private set; }

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