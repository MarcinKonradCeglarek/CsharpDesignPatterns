namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;

    public class CompositeNode : IComposite
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
}