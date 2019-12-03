using System.Collections.Generic;

namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    internal class AccessoriesDrawer
    {
        public IEnumerable<string> GetCasualAccessories()
        {
            return new [] { "Fitbit" };
        }

        public IEnumerable<string> GetSmartAccessories()
        {
            return new[] { "Watch", "Tie", "Belt" };
        }
    }
}