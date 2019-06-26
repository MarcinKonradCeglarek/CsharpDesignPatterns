namespace CSharpDesignPatterns._3._SOLID_principles
{
    using System;
    using System.Collections.Generic;

    internal class InterfaceSegregation : IRepository<int>
    {
        private int a;

        public InterfaceSegregation(int a)
        {
            this.a = a;
        }

        public Dictionary<Guid, int> Data { get; } = new Dictionary<Guid, int>();

        public void GET_Data()
        {

        }

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

    interface IRepository<T>
    {
        Guid Create(T x);
        T Read(Guid id);
        void Update(T x);
        void Delete(Guid id);
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