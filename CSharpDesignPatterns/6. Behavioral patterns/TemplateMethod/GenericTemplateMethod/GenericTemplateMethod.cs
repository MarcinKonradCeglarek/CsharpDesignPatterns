namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    internal abstract class GenericTemplateMethod<TParent, TChild>
    {
        public void AddToParent(TParent parent, TChild child)
        {
            if (!this.IsChild(parent, child))
            {
                this.AddChild(parent, child);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void RemoveFromParent(TParent parent, TChild child)
        {
            if (this.IsChild(parent, child))
            {
                this.RemoveChild(parent, child);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void MoveChildBetweenParents(TParent oldParent, TParent newParent, TChild child)
        {
            if (this.IsChild(oldParent, child) && !this.IsChild(newParent, child))
            {
                this.RemoveChild(oldParent, child);
                this.AddChild(newParent, child);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        protected abstract void AddChild(TParent    parent, TChild child);
        protected abstract bool IsChild(TParent     parent, TChild child);
        protected abstract void RemoveChild(TParent parent, TChild child);
    }
}