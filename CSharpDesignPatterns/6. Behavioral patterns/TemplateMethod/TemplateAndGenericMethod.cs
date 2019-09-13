namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    internal abstract class TemplateMethod2<TParent, TChild>
    {
        public void ChangeParent(TChild child, TParent oldParent, TParent newParent)
        {
            if (this.IsChild(oldParent, child))
            {
                this.RemoveChild(oldParent, child);
                this.AddChild(newParent, child);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        protected abstract void AddChild(TParent    newParent, TChild child);
        protected abstract bool IsChild(TParent     parent,    TChild child);
        protected abstract void RemoveChild(TParent oldParent, TChild child);
    }

    internal class CompanyManager : TemplateMethod2<Company, Employee>
    {
        protected override void AddChild(Company newParent, Employee child)
        {
            newParent.Hire(child.Person, "newTitle", 10000);
        }

        protected override bool IsChild(Company parent, Employee child)
        {
            return parent.Employees.ContainsKey(child.Person.Id);
        }

        protected override void RemoveChild(Company oldParent, Employee child)
        {
            oldParent.Sack(child.Person.Id);
        }
    }
}