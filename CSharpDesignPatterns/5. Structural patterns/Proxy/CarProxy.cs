namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    using CSharpDesignPatterns._5._Structural_patterns.Proxy.Model;

    public interface ICar
    {
        string DriveCar();
    }

    public class CarProxy : ICar
    {
        public CarProxy(Driver driver, ICar car)
        {
            throw new NotImplementedException();
        }

        public string DriveCar()
        {
            throw new NotImplementedException();
        }
    }
}