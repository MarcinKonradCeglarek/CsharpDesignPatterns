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
            // Connnect to SQL db
            throw new NotImplementedException();
        }

        public int Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(int x)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    /*public class Calc
    {
        public Calc(IRepository<int> data)
        {
            this.Data = data;
        }

        public IRepository<int> Data { get; }

        public int SumAllOddFields()
        {

        }
    }*/
}