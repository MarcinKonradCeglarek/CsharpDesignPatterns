namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns._5._Structural_patterns.Facade.Model;

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
            var shoes = this.shoesCloset.GetCasualShoes();
            var clothes = this.wardrobe.GetCasualWear();
            var accesories = this.accessoriesDrawer.GetCasualAccessories();

            return $"Casual clothes: [{shoes},{clothes},{accesories}]";
        }

        public string GetSmartClothes()
        {
            var shoes      = this.shoesCloset.GetSmartShoes();
            var clothes    = this.wardrobe.GetSuit();
            var accesories = this.accessoriesDrawer.GetSmartAccessories();

            return $"Smart clothes: [{shoes},{clothes},{accesories}]";
        }
    }
}