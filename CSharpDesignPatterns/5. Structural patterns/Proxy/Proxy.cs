namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    public interface ICar
    {
        string DriveCar();
    }

    public class ProxyCar : ICar
    {
        private readonly ICar   car;
        private readonly Driver driver;

        public ProxyCar(Driver driver, ICar car)
        {
            this.driver = driver;
            this.car    = car;
        }

        public string DriveCar()
        {
            if (this.driver.HasDrivingLicense && this.driver.Age >= 18)
            {
                return this.car.DriveCar();
            }

            throw new InvalidOperationException();
        }
    }

    public class Car : ICar
    {
        public string DriveCar()
        {
            return "Car has been driven!";
        }
    }

    public class Driver
    {
        public Driver(int age, bool hasDrivingLicense)
        {
            this.Age               = age;
            this.HasDrivingLicense = hasDrivingLicense;
        }

        public int  Age               { get; }
        public bool HasDrivingLicense { get; }
    }
}