namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System.Collections.Generic;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    public class Node<T>
    {
        private readonly IEnumerable<T> childrenIds;
        private IReadOnlyList<Node<T>> children = null;

        public Node(T thisId, IEnumerable<T> childrenIds, IRepository<T, Node<T>> repository)
        {
            this.Id = thisId;
            this.childrenIds = childrenIds;
            this.Repository = repository;
        }

        public T Id { get; }

        public IReadOnlyList<Node<T>> Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = this.childrenIds.Select(i => this.Repository.Read(i)).ToList();
                }

                return this.children;
            }
        }

        private IRepository<T, Node<T>> Repository { get; }
    }
}