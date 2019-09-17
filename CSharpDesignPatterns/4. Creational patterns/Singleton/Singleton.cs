namespace CSharpDesignPatterns._4._Creational_patterns.Singleton
{
    using System;

    /*
     * https://refactoring.guru/design-patterns/singleton
     */
    internal class Singleton
    {
        private Singleton()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public static Singleton GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}