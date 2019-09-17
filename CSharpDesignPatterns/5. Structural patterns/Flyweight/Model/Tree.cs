namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight.Model
{
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