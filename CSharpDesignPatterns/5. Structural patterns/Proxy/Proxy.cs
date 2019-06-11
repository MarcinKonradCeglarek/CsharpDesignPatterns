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
        private readonly Driver driver;

        private readonly ICar realCar;

        public ProxyCar(Driver driver)
        {
            this.driver = driver;
            this.realCar = new Car();
        }

        public string DriveCar()
        {
            if (this.driver.Age < 16)
            {
                throw new InvalidOperationException("Driver is too young");
            }

            return this.realCar.DriveCar();
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