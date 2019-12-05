namespace CSharpDesignPatterns._4._Creational_patterns.Singleton
{
    using System;

    /*
     * https://refactoring.guru/design-patterns/singleton
     */
    internal class SingletonViaLocking
    {
        private static readonly object              Semaphore = new object();
        private static          SingletonViaLocking instance;

        private SingletonViaLocking()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public static SingletonViaLocking GetInstance()
        {
            // Lock is required, so multiple threads doesn't create multiple instances
            lock (Semaphore)
            {
                if (instance == null)
                {
                    instance = new SingletonViaLocking();
                }

                return instance;
            }
        }
    }

    /*
     * This solution doesn't require locking, but will be created automatically (we can't affect when)
     */
    internal class SingletonViaStaticConstructor
    {
        private static readonly SingletonViaStaticConstructor Instance = new SingletonViaStaticConstructor();

        private SingletonViaStaticConstructor()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public static SingletonViaStaticConstructor GetInstance() => Instance;
    }
}