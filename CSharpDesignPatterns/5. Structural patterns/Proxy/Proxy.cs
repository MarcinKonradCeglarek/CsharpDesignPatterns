namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    internal interface ICar
    {
        string DriveCar();
    }

    internal class Car : ICar
    {
        public string DriveCar()
        {
            return "Car has been driven!";
        }
    }

    internal class ProxyCar : ICar
    {
        public ProxyCar(Driver driver)
        {
            throw new NotImplementedException();
        }

        public string DriveCar()
        {
            throw new NotImplementedException();
        }
    }

    internal class Driver
    {
        public Driver(int age)
        {
            this.Age = age;
        }

        public int Age { get; }
    }
}