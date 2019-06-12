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
        private readonly ICar car;

        public ProxyCar(Driver driver, ICar car)
        {
            this.car = car;
            this.Driver = driver;
        }

        public Driver Driver { get; set; }

        public string DriveCar()
        {
            if (this.Driver.Age >= 18)
            {
                return this.car.DriveCar();
            }

            throw new InvalidOperationException();
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