namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    internal abstract class GenericTemplateMethod<TParent, TChild>
    {
        public void AddToParent(TParent parent, TChild child)
        {
            if (this.IsChild(parent, child))
            {
                throw new InvalidOperationException();
            }

            this.AddChild(parent, child);
        }

        public void RemoveFromParent(TParent parent, TChild child)
        {
            if (!this.IsChild(parent, child))
            {
                throw new InvalidOperationException();
            }

            this.RemoveChild(parent, child);
        }

        public void MoveChildBetweenParents(TParent oldParent, TParent newParent, TChild child)
        {
            /*
             * Is child a children element of oldParent and not children element of newParent
             *    remove child from oldParent
             *    add child to newParent
             * else
             *    throw InvalidOperationException
             */
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
        protected abstract bool IsChild(TParent     parent,    TChild child);
        protected abstract void RemoveChild(TParent parent, TChild child);
    }
}