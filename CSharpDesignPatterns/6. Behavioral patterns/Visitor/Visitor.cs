namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
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

    public interface IComponent
    {
        void Accept(IVechicleVisitor vechicleVisitor);
    }


    public class Car : IComponent
    {
        public Car(int seats)
        {
            this.Passengers = seats - 1;
        }

        public int Passengers { get; }

        public void Accept(IVechicleVisitor vechicleVisitor)
        {
            vechicleVisitor.Visit(this);
        }
    }

    public class Truck : IComponent
    {
        public Truck(double capacity)
        {
            this.CargoCapacity = capacity;
        }

        public double CargoCapacity { get; }

        public void Accept(IVechicleVisitor vechicleVisitor)
        {
            vechicleVisitor.Visit(this);
        }
    }

    public class Bus : IComponent
    {
        public void Accept(IVechicleVisitor vechicleVisitor)
        {
            vechicleVisitor.Visit(this);
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
        private double cargoValue;
        public double GetTotalCargoValue => this.cargoValue;

        public void Visit(Car car)
        {
            this.cargoValue += 200;
        }

        public void Visit(Truck truck)
        {
            this.cargoValue += truck.CargoCapacity;
        }

        public void Visit(Bus bus)
        {
        }
    }

    public class PassengersCapacityVisitor : IVechicleVisitor
    {
        private int passengers = 0;
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
