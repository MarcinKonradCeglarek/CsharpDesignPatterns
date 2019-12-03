using System.Collections.Generic;

namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    internal class ShoesCloset
    {
        public IEnumerable<string> GetCasualShoes()
        {
            return new [] { "Sneakers" };
        }

        public IEnumerable<string> GetSmartShoes()
        {
            return new []{ "Formal Shoes" };
        }
    }
}