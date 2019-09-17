namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    using System;

    public class Car : IVehicle
    {
        public Car(int seats)
        {
            throw new NotImplementedException();
        }

        public int Passengers { get; }

        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            throw new NotImplementedException();
        }
    }
}