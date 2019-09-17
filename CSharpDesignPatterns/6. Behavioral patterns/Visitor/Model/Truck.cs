namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    using System;

    public class Truck : IVehicle
    {
        public Truck(double capacity)
        {
            this.CargoCapacity = capacity;
        }

        public double CargoCapacity { get; }

        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            vehicleVisitor.Visit(this);
        }
    }
}