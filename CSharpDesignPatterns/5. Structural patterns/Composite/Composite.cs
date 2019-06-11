namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System.Collections.Generic;
    using System.Linq;

    internal interface IComposite
    {
        string Print();
    }

    internal class Composite : IComposite
    {
        private readonly List<IComposite> children = new List<IComposite>();

        public void Add(IComposite node)
        {
            this.children.Add(node);
        }

        public string Print()
        {
            return $"[{string.Join(",", this.children.Select(c => c.Print()))}]";
        }
    }

    internal class Leaf : IComposite
    {
        public string Name { get; }

        public Leaf(string name)
        {
            this.Name = name;
        }

        public string Print()
        {
            return this.Name;
        }
    }
}