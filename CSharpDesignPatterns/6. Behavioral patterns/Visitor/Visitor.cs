namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;

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

    public interface IVehicle
    {
        void Accept(IVehicleVisitor vehicleVisitor);
    }


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

    public class Truck : IVehicle
    {
        public Truck(double capacity)
        {
            throw new NotImplementedException();
        }

        public double CargoCapacity { get; }

        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            throw new NotImplementedException();
        }
    }

    public class Bus : IVehicle
    {
        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            throw new NotImplementedException();
        }
    }

    public interface IVehicleVisitor
    {
        void Visit(Car car);
        void Visit(Truck truck);
        void Visit(Bus bus);
    }

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

    public class PassengersCapacityVisitor : IVehicleVisitor
    {
        public int PassengersCapacity => throw new NotImplementedException();

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

    public class Client
    {
        public static void Visit(List<IVehicle> components, IVehicleVisitor vehicleVisitor)
        {
            foreach (var component in components)
            {
                component.Accept(vehicleVisitor);
            }
        }
    }
}
