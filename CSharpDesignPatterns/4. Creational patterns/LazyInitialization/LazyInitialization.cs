namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using CSharpDesignPatterns.Common.Model;

    public class Node<T>
    {
        public Node(T id, IEnumerable<T> childrenIds, IRepository<T, Node<T>> repository)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Node<T>> Children { get; }

        private IRepository<T, Node<T>> Repository { get; }
    }
}