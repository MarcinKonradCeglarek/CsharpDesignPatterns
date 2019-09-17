namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    using System;

    public class Bus : IVehicle
    {
        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            throw new NotImplementedException();
        }
    }
}