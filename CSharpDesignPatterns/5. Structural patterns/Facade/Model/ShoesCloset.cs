namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    using System.Collections.Generic;

    internal class ShoesCloset
    {
        public IEnumerable<string> GetCasualShoes()
        {
            return new[] { "Sneakers" };
        }

        public IEnumerable<string> GetSmartShoes()
        {
            return new[] { "Formal Shoes" };
        }
    }
}