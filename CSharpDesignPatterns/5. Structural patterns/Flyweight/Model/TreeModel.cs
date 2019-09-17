namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;

    /*
     * This object is very memory heavy and should be made flyweight :-)
     */
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
}