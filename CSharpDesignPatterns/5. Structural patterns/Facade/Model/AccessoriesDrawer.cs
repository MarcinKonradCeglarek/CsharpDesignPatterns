namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    using System.Collections.Generic;

    internal class AccessoriesDrawer
    {
        public IEnumerable<string> GetCasualAccessories()
        {
            return new[] { "Fitbit" };
        }

        public IEnumerable<string> GetSmartAccessories()
        {
            return new[] { "Watch", "Tie", "Belt" };
        }
    }
}