namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    internal abstract class GenericTemplateMethod<TParent, TChild>
    {
        public void AddToParent(TParent parent, TChild child)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromParent(TParent parent, TChild child)
        {
            throw new NotImplementedException();
        }

        public void MoveChild(TParent oldParent, TParent newParent, TChild child)
        {
            /*
             * Is child a children element of oldParent and not children element of newParent
             *    remove child from oldParent
             *    add child to newParent
             * else
             *    throw InvalidOperationException
             */

            throw new NotImplementedException();
        }

        protected abstract void AddChild(TParent    parent, TChild child);
        protected abstract bool IsChild(TParent     parent,    TChild child);
        protected abstract void RemoveChild(TParent parent, TChild child);
    }
}