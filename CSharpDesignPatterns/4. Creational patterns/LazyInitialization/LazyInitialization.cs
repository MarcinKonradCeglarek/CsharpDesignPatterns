namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System.Collections.Generic;

    public class Node
    {
        public string Name { get; }

        private IChildrenRepository ChildrenRepository { get; }

        public Node(string name, IChildrenRepository childrenRepository)
        {
            this.Name = name;
            this.ChildrenRepository = childrenRepository;
        }

        public IEnumerable<Node> Children
        {
            get
            {
                return null;
            }
        }
    }

    public interface IChildrenRepository
    {
        IEnumerable<Node> GetChildrenByName(string name);
    }
}