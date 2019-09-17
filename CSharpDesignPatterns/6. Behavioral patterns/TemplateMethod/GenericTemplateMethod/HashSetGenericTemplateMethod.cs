namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Collections.Generic;

    internal class HashSetGenericTemplateMethod : GenericTemplateMethod<HashSet<int>, int>
    {
        protected override void AddChild(HashSet<int> parent, int child)
        {
            throw new NotImplementedException();
        }

        protected override bool IsChild(HashSet<int> parent, int child)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveChild(HashSet<int> parent, int child)
        {
            throw new NotImplementedException();
        }
    }
}