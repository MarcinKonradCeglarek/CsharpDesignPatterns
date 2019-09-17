namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;

    public class CompositeLeaf : IComposite
    {
        private readonly string name;

        public CompositeLeaf(string name)
        {
            this.name = name;
        }

        public IReadOnlyCollection<IComposite> Children { get; }

        public string Print()
        {
            return this.name;
        }
    }
}