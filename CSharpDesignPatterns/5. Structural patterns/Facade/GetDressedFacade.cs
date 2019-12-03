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

        public IEnumerable<string> GetCasualClothes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetSmartClothes()
        {
            throw new NotImplementedException();
        }
    }
}