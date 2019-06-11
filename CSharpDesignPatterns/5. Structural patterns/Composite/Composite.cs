namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal interface IComposite
    {
        string Print();
    }

    internal class Composite : IComposite
    {
        public void Add(IComposite composite)
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }

    internal class Leaf : IComposite
    {
        public Leaf(string name)
        {
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}