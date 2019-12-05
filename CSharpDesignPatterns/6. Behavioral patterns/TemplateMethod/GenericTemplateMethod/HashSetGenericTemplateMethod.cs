namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;

    internal class HashSetGenericTemplateMethod : GenericTemplateMethod<HashSet<int>, int>
    {
        protected override void AddChild(HashSet<int> parent, int child)
        {
            parent.Add(child);
        }

        protected override bool IsChild(HashSet<int> parent, int child)
        {
            return parent.Contains(child);
        }

        protected override void RemoveChild(HashSet<int> parent, int child)
        {
            parent.Remove(child);
        }
    }
}