namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    public class NodeWithLazyChildren<T>
    {
        private readonly IEnumerable<T> childrenIds;
        private readonly IRepository<T, NodeWithLazyChildren<T>> repository;
        private List<NodeWithLazyChildren<T>> children;

        public NodeWithLazyChildren(T thisId, IEnumerable<T> childrenIds, IRepository<T, NodeWithLazyChildren<T>> repository)
        {
            this.childrenIds = childrenIds;
            this.repository = repository;
            this.Id = thisId;
        }

        public IReadOnlyList<NodeWithLazyChildren<T>> Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = this.childrenIds.Select(id => this.repository.Read(id)).ToList();
                }

                return new ReadOnlyCollection<NodeWithLazyChildren<T>>(this.children);
            }
        }
        
        public T Id { get; }
    }
}