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

    public class PassengersCapacityVisitor : IVehicleVisitor
    {
        private int passengers;
        public int PassengersCapacity => this.passengers;

        public void Visit(Car car)
        {
            this.passengers += car.Passengers;
        }

        public void Visit(Truck truck)
        {
        }

        public void Visit(Bus bus)
        {
            this.passengers += 40;
        }
    }
}