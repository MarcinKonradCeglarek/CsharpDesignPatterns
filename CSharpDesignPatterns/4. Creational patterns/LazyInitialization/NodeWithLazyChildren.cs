namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns.Common.Model;

    public class NodeWithLazyChildren<T>
    {
        public NodeWithLazyChildren(
            T                                       thisId,
            IEnumerable<T>                          childrenIds,
            IRepository<T, NodeWithLazyChildren<T>> repository)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<NodeWithLazyChildren<T>> Children => throw new NotImplementedException();

        public T Id { get; }

        private IRepository<T, NodeWithLazyChildren<T>> Repository { get; }
    }
}