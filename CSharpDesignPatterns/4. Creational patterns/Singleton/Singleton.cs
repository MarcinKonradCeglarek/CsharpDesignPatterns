namespace CSharpDesignPatterns._4._Creational_patterns.Singleton
{
    using System;
    using System.Threading;

    /*
     * https://refactoring.guru/design-patterns/singleton
     */
    internal class Singleton
    {
        private static readonly object Semaphore = new object();
        private static Singleton instance;

        private Singleton()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public static Singleton GetInstance()
        {
            lock (Semaphore)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }
}