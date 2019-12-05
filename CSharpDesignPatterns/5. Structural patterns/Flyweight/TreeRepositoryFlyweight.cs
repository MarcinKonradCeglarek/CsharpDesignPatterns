namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System.Collections.Generic;

    using CSharpDesignPatterns._5._Structural_patterns.Flyweight.Model;

    internal class TreeRepositoryFlyweight
    {
        private int                            counter;
        public  IDictionary<int, Tree>         Trees      { get; } = new Dictionary<int, Tree>();
        public  IDictionary<string, TreeModel> TreeModels { get; } = new Dictionary<string, TreeModel>();

        public int CreateTree(TreeModel treeModel, Position position)
        {
            return this.CreateTree(treeModel.Name, position);
        }

        public int CreateTree(string name, Position position)
        {
            if (!this.TreeModels.ContainsKey(name))
            {
                this.TreeModels.Add(name, new TreeModel(name));
            }

            var id    = this.counter++;
            var model = this.TreeModels[name];
            this.Trees.Add(id, new Tree(model, position));
            return id;
        }
    }
}