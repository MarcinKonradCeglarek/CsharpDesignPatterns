namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Node
    {
        private IList<Node> children;

        public Node(string name, IChildrenRepository childrenRepository)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Node> Children
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name { get; }

        private IChildrenRepository ChildrenRepository { get; }
    }

    public interface IChildrenRepository
    {
        IList<Node> GetChildrenByName(string name);
    }
}