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
        private readonly IList<IComposite> children = new List<IComposite>();

        public void Add(IComposite composite)
        {
            this.children.Add(composite);
        }

        public string Print()
        {
            return $"[{string.Join(",", this.children.Select(g => g.Print()))}]";
        }
    }

    internal class Leaf : IComposite
    {
        public Leaf(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public string Print()
        {
            return this.Name;
        }
    }
}