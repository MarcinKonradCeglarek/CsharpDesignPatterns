namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    public interface ICar
    {
        string DriveCar();
    }

    public class Car : ICar
    {
        public string DriveCar()
        {
            return "Car has been driven!";
        }
    }

    public class ProxyCar : ICar
    {
        private readonly ICar car;

        public ProxyCar(Driver driver, ICar car)
        {
            this.car    = car;
            this.Driver = driver;
        }

        public Driver Driver { get; set; }

        public string DriveCar()
        {
            if (this.Driver.Age >= 18 && this.Driver.HasDrivingLicense)
            {
                return this.car.DriveCar();
            }

            throw new InvalidOperationException();
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