namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public interface IComposite
    {
        IReadOnlyCollection<IComposite> Children { get; }
        string                          Print();
    }

    public class Composite : IComposite
    {
        public IReadOnlyCollection<IComposite> Children { get; }

        public void Add(IComposite node)
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }

    public class Leaf : IComposite
    {
        public Leaf(string name)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IComposite> Children { get; }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}