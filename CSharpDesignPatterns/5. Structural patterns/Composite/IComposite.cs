namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using System.Collections.Generic;

    public interface IComposite
    {
        IReadOnlyCollection<IComposite> Children { get; }
        string                          Print();
    }
}