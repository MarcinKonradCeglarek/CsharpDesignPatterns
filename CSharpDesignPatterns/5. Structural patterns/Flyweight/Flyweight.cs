namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    internal class FlyweightTreeRepository
    {
        public IDictionary<Guid, Tree> Trees     { get; } = new Dictionary<Guid, Tree>();
        public IDictionary<string, TreeModel> TreeTypes { get; } = new Dictionary<string, TreeModel>();

        public Guid CreateTree(TreeModel treeModel, Position position)
        {
            return this.CreateTree(treeModel.Name, position);
        }

        public Guid CreateTree(string name, Position position)
        {
            TreeModel treeModel;
            if (this.TreeTypes.ContainsKey(name))
            {
                treeModel = this.TreeTypes[name];
            }
            else
            {
                treeModel = new TreeModel(name);
                this.TreeTypes.Add(name, treeModel);
            }

            var newId = Guid.NewGuid();
            this.Trees.Add(newId, new Tree(treeModel, position));
            return newId;
        }
    }

    public class TreeModel
    {
        public TreeModel(string name)
        {
            this.Name = name;
            this.Id   = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Id}";
        }
    }

    public struct Position
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public Position(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public struct Tree
    {
        public readonly TreeModel TreeModel;
        public readonly Position  Position;

        public Tree(TreeModel treeModel, Position position)
        {
            this.TreeModel = treeModel;
            this.Position  = position;
        }
    }
}