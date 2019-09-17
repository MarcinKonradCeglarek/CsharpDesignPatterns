namespace CSharpDesignPatterns._5._Structural_patterns.Facade.Model
{
    internal class Wardrobe
    {
        public string GetCasualWear()
        {
            return "T-Shirt,Shorts";
        }

        public string GetSuit()
        {
            return "Formal Jacket,Formal Trousers,Formal Shirt";
        }
    }
}