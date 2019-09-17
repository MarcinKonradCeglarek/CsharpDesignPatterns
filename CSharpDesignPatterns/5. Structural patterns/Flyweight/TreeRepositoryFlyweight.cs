namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns._5._Structural_patterns.Flyweight.Model;

    internal class TreeRepositoryFlyweight
    {
        public IDictionary<int, Tree> Trees      { get; } = new Dictionary<int, Tree>();
        public IDictionary<string, TreeModel> TreeModels { get; } = new Dictionary<string, TreeModel>();

        public int CreateTree(TreeModel treeModel, Position position)
        {
            throw new NotImplementedException();
        }

        public int CreateTree(string name, Position position)
        {
            throw new NotImplementedException();
        }
    }
}