namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;

    using CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model;

    /*
     * https://refactoring.guru/design-patterns/visitor
     *
     * Cars:
     *     Passengers: seats - 1 (driver)
     *     Cargo: 200
     *
     * Buss:
     *     Passengers: 40
     *     Cargo: none
     *
     * Truck
     *     Passengers: none
     *     Cargo: capacity
     *
     *
     * CargoCapacityVisitor: sums cargo capacity of all vehicles
     * PassengersCapacityVisitor: sums available passengers for all vehicles
     *
     */
    public class CargoCapacityVisitor : IVehicleVisitor
    {
        public double GetTotalCargoValue => throw new NotImplementedException();

        public void Visit(Car car)
        {
            throw new NotImplementedException();
        }

        public void Visit(Truck truck)
        {
            throw new NotImplementedException();
        }

        public void Visit(Bus bus)
        {
            throw new NotImplementedException();
        }
    }
}