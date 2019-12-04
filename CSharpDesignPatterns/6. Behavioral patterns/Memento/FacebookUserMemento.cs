using System.Collections.Generic;

namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Immutable;

    public class FacebookUserMemento
    {
        public readonly List<string> Friends;
        public readonly string                Name;

        public FacebookUserMemento(string name, List<string> friends)
        {
            throw new NotImplementedException();
        }
    }
}