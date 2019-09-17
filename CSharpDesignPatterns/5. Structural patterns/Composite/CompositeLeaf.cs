namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;

    public class CompositeLeaf : IComposite
    {
        public CompositeLeaf(string name)
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