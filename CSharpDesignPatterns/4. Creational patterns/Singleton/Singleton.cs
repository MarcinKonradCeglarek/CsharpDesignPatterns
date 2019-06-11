namespace CSharpDesignPatterns._4._Creational_patterns.Singleton
{
    using System;

    internal class Singleton
    {
        private static readonly Singleton Instance = new Singleton();

        private Singleton()
        {
            this.Id = Guid.NewGuid();
        }

        public static Singleton GetInstance()
        {
            return Instance;
        }

        public Guid Id { get; }
    }
}