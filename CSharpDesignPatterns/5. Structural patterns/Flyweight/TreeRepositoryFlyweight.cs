namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns._5._Structural_patterns.Flyweight.Model;

    internal class TreeRepositoryFlyweight
    {
        private int counter = 0;
        public IDictionary<int, Tree> Trees      { get; } = new Dictionary<int, Tree>();
        public IDictionary<string, TreeModel> TreeModels { get; } = new Dictionary<string, TreeModel>();

        public int CreateTree(TreeModel treeModel, Position position)
        {
            return this.CreateTree(treeModel.Name, position);
        }

        public int CreateTree(string name, Position position)
        {
            var treeModel = new TreeModel(name);
            if (!this.TreeModels.ContainsKey(name))
            {
                this.TreeModels.Add(treeModel.Name, treeModel);
            }

            this.Trees.Add(counter, new Tree(treeModel, position));
            return counter++;
        }
    }
}