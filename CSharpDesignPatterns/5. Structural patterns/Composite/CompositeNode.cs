namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class CompositeNode : IComposite
    {
        private readonly List<IComposite> children = new List<IComposite>();
        public IReadOnlyCollection<IComposite> Children => new ReadOnlyCollection<IComposite>(this.children);

        public void Add(IComposite node)
        {
            this.children.Add(node);
        }

        public string Print()
        {
            return $"[{string.Join(",", this.children.Select(c => c.Print()))}]";
        }
    }
}