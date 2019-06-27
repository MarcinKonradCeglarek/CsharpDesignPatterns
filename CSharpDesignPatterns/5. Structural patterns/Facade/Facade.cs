namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    using System;

    using NUnit.Framework.Internal;

    internal class ShoesCloset
    {
        public string GetSmartSchoes()
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
            return "Formal Jacket, Formal Trousers, Formal Shirt";
        }

        public string GetCasualWear()
        {
            return "T-Shirt, Shorts";
        }
    }

    internal class AccesoriesDrawer
    {
        public string GetSmartAccessories()
        {
            return "Watch, Tie, Belt";
        }

        public string GetCasualAccessories()
        {
            return "Fitbit";
        }
    }

    public class GetDressedFacade
    {
        private readonly ShoesCloset shoesCloset = new ShoesCloset();
        private readonly Wardrobe wardrobe = new Wardrobe();
        private readonly AccesoriesDrawer accesoriesDrawer = new AccesoriesDrawer();

        public string GetSmartClothes()
        {
            var resultA = this.shoesCloset.GetSmartSchoes();
            var resultB = this.wardrobe.GetSuit();
            var resultC = this.accesoriesDrawer.GetSmartAccessories();

            return $"SmartClothes: [{resultA},{resultB},{resultC}]";
        }

        public string GetCasualClothes()
        {
            var resultA = this.shoesCloset.GetCasualShoes();
            var resultB = this.wardrobe.GetCasualWear();
            var resultC = this.accesoriesDrawer.GetCasualAccessories();

            return $"Casual clothes: [{resultA},{resultB},{resultC}]";
        }
    }
}
