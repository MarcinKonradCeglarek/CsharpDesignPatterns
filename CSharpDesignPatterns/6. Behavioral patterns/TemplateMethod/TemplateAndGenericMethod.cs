namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    internal abstract class TemplateMethod2<TParent, TChild>
    {
        public void ChangeParent(TChild child, TParent oldParent, TParent newParent)
        {
            /*
             * Is child a children element of oldParent
             *    remove child from oldParent
             *    add child to newParent
             * else
             *    throw InvalidOperationException
             */
            throw new NotImplementedException();
        }

        protected abstract void AddChild(TParent    newParent, TChild child);
        protected abstract bool IsChild(TParent     parent,    TChild child);
        protected abstract void RemoveChild(TParent oldParent, TChild child);
    }

    internal class CompanyManager : TemplateMethod2<Company, Employee>
    {
        protected override void AddChild(Company newParent, Employee child)
        {
            throw new NotImplementedException();
        }

        protected override bool IsChild(Company parent, Employee child)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveChild(Company oldParent, Employee child)
        {
            throw new NotImplementedException();
        }
    }
}