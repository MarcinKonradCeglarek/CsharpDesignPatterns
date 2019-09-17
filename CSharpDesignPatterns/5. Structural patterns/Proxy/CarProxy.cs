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
        private readonly Driver driver;
        private readonly ICar car;

        public CarProxy(Driver driver, ICar car)
        {
            this.driver = driver;
            this.car = car;
        }

        public string DriveCar()
        {
            if (this.driver.HasDrivingLicense && this.driver.Age >= 18)
            {
                return this.car.DriveCar();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}