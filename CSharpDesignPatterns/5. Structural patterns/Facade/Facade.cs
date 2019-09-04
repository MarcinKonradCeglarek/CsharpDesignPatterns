namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    using System;

    using NUnit.Framework.Internal;

    public class GetDressedFacade
    {
        private readonly ShoesCloset       shoesCloset       = new ShoesCloset();
        private readonly Wardrobe          wardrobe          = new Wardrobe();
        private readonly AccessoriesDrawer accessoriesDrawer = new AccessoriesDrawer();

        public string GetSmartClothes()
        {
            throw new NotImplementedException();
        }

        public string GetCasualClothes()
        {
            throw new NotImplementedException();
        }
    }

    internal class ShoesCloset
    {
        public string GetSmartShoes()
        {
            return "Formal Shoes";
        }

        public string GetCasualShoes()
        {
            return "Sneakers";
        }
    }

    internal class Wardrobe
    {
        public string GetSuit()
        {
            return "Formal Jacket,Formal Trousers,Formal Shirt";
        }

        public string GetCasualWear()
        {
            return "T-Shirt,Shorts";
        }
    }

    internal class AccessoriesDrawer
    {
        public string GetSmartAccessories()
        {
            return "Watch,Tie,Belt";
        }

        public string GetCasualAccessories()
        {
            return "Fitbit";
        }
    }
}
