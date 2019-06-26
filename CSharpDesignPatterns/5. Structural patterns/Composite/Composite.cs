namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IComposite
    {
        string Print();
    }

    public class Composite : IComposite
    {
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
            this.Name = name;
        }

        public string Name { get; }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}