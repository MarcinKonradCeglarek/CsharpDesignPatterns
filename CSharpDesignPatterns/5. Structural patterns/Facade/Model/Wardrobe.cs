using System.Collections.Generic;

namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    internal class Wardrobe
    {
        public IEnumerable<string> GetCasualWear()
        {
            return new[] {"T-Shirt", "Shorts"};
        }

        public IEnumerable<string> GetSuit()
        {
            return new[] {"Formal Jacket", "Formal Trousers", "Formal Shirt"};
        }
    }
}