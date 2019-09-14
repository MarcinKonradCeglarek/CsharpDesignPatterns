namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    using System;

    /*
     * https://refactoring.guru/design-patterns/facade
     */
    public class GetDressedFacade
    {
        private readonly AccessoriesDrawer accessoriesDrawer = new AccessoriesDrawer();
        private readonly ShoesCloset       shoesCloset       = new ShoesCloset();
        private readonly Wardrobe          wardrobe          = new Wardrobe();

        public string GetCasualClothes()
        {
            throw new NotImplementedException();
        }

        public string GetSmartClothes()
        {
            throw new NotImplementedException();
        }
    }

    internal class ShoesCloset
    {
        public string GetCasualShoes()
        {
            return "Sneakers";
        }

        public string GetSmartShoes()
        {
            return "Formal Shoes";
        }
    }

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

    internal class AccessoriesDrawer
    {
        public string GetCasualAccessories()
        {
            return "Fitbit";
        }

        public string GetSmartAccessories()
        {
            return "Watch,Tie,Belt";
        }
    }
}