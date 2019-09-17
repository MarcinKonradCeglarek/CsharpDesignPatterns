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
        private double cargo;
        public double GetTotalCargoValue => this.cargo;

        public void Visit(Car car)
        {
            this.cargo += 200;
        }

        public void Visit(Truck truck)
        {
            this.cargo += truck.CargoCapacity;
        }

        public void Visit(Bus bus)
        {
        }
    }
}