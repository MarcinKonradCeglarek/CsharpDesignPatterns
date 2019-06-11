namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Node
    {
        private IList<Node> children;

        public Node(string name, IChildrenRepository childrenRepository)
        {
            this.Name               = name;
            this.ChildrenRepository = childrenRepository;
        }

        public IReadOnlyList<Node> Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = this.ChildrenRepository.GetChildrenByName(this.Name);
                }

                return new ReadOnlyCollection<Node>(this.children);
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