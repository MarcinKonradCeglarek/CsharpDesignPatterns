namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    using System.Collections.Generic;

    internal class Wardrobe
    {
        public IEnumerable<string> GetCasualWear()
        {
            return new[] { "T-Shirt", "Shorts" };
        }

        public IEnumerable<string> GetSuit()
        {
            return new[] { "Formal Jacket", "Formal Trousers", "Formal Shirt" };
        }
    }
}