namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

    public interface IComponent
    {
        void Accept(IVechicleVisitor vechicleVisitor);
    }


    public class Car : IComponent
    {
        public Car(int seats)
        {
        }

        public int Passengers { get; }

        public void Accept(IVechicleVisitor vechicleVisitor)
        {
            throw new NotImplementedException();
        }
    }

    public class Truck : IComponent
    {
        public Truck(double capacity)
        {
        }

        public double CargoCapacity { get; }

        public void Accept(IVechicleVisitor vechicleVisitor)
        {
            throw new NotImplementedException();
        }
    }

    public class Bus : IComponent
    {
        public void Accept(IVechicleVisitor vechicleVisitor)
        {
            throw new NotImplementedException();
        }
    }

    public interface IVechicleVisitor
    {
        void Visit(Car car);
        void Visit(Truck truck);
        void Visit(Bus bus);
    }

    public class CargoCapacityVisitor : IVechicleVisitor
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

    public class PassengersCapacityVisitor : IVechicleVisitor
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
        public static void Visit(List<IComponent> components, IVechicleVisitor vechicleVisitor)
        {
            foreach (var component in components)
            {
                component.Accept(vechicleVisitor);
            }
        }
    }
}
