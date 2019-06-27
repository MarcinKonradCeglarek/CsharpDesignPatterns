namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    public interface ICar
    {
        string DriveCar();
    }

    public class ProxyCar : ICar
    {
        private readonly ICar car;

        public ProxyCar(Driver driver, ICar car)
        {
        }

        public Driver Driver { get; set; }

        public string DriveCar()
        {
            throw new NotImplementedException();
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