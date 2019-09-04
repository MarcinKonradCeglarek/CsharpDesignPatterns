namespace CSharpDesignPatterns._3._SOLID_principles
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns.Common.Model;

    internal class InterfaceSegregation : IRepository<Guid, int>
    {
        public Dictionary<Guid, int> Data { get; } = new Dictionary<Guid, int>();

        public Guid Create(int x)
        {
            throw new NotImplementedException();
        }

        public int Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, int x)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}