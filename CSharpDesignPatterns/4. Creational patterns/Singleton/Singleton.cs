namespace CSharpDesignPatterns._4._Creational_patterns.Singleton
{
    using System;

    internal class Singleton
    {
        private Singleton()
        {
            this.Id = Guid.NewGuid();
        }

        public static Singleton GetInstance()
        {
            return null;
        }

        public Guid Id { get; }
    }
}