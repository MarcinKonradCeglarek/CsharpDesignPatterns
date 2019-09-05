namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    using System;

    using NUnit.Framework.Internal;

    /*
     * https://refactoring.guru/design-patterns/facade
     */
    public class GetDressedFacade
    {
        private readonly ShoesCloset       shoesCloset       = new ShoesCloset();
        private readonly Wardrobe          wardrobe          = new Wardrobe();
        private readonly AccessoriesDrawer accessoriesDrawer = new AccessoriesDrawer();

        public string GetSmartClothes()
        {
            var resultA = this.shoesCloset.GetSmartShoes();
            var resultB = this.wardrobe.GetSuit();
            var resultC = this.accessoriesDrawer.GetSmartAccessories();

            return $"SmartClothes: [{resultA},{resultB},{resultC}]";
        }

        public string GetCasualClothes()
        {
            var resultA = this.shoesCloset.GetCasualShoes();
            var resultB = this.wardrobe.GetCasualWear();
            var resultC = this.accessoriesDrawer.GetCasualAccessories();

            return $"Casual clothes: [{resultA},{resultB},{resultC}]";
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
