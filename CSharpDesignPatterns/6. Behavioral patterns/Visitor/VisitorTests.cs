namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model;

    using NUnit.Framework;

    [TestFixture]
    public class VisitorTests
    {
        private const int ExpectedPassengers = 40 + 40 + 4 + 3;
        private const double ExpectedCargo = 5000 + 7500 + 200 + 200;

        private readonly List<IVehicle> components = new List<IVehicle>
            {
                new Car(5),
                new Truck(5000),
                new Bus(),
                new Bus(),
                new Truck(7500),
                new Car(4)
            };

        [Test]
        public void PassengersCapacityVisitor()
        {
            var passengersCapacityVisitor = new PassengersCapacityVisitor();

            // Act
            foreach (var component in this.components)
            {
                component.Accept(passengersCapacityVisitor);
            }

            // Assert
            Assert.AreEqual(ExpectedPassengers, passengersCapacityVisitor.PassengersCapacity);
        }

        [Test]
        public void CargoCapacityVisitor()
        {
            var cargoCapacityVisitor = new CargoCapacityVisitor();

            // Act
            foreach (var component in this.components)
            {
                component.Accept(cargoCapacityVisitor);
            }

            // Assert
            Assert.AreEqual(ExpectedCargo, cargoCapacityVisitor.GetTotalCargoValue);
        }

        [Test]
        public void PassengersCapacityWithLinq()
        {
            Func<IVehicle, int> getPassengers = component =>
                {
                    if (component is Car car)
                    {
                        return car.Passengers;
                    }

                    if (component is Bus)
                    {
                        return 40;
                    }

                    return 0;
                };

            var passengers = this.components.Sum(c => getPassengers(c));

            Assert.AreEqual(ExpectedPassengers, passengers);
        }

        [Test]
        public void HomeAndParkUsingLinq()
        {
            Func<IVehicle, double> getCargoCapacity = component =>
                {
                    if (component is Truck truck)
                    {
                        return truck.CargoCapacity;
                    }

                    if (component is Car)
                    {
                        return 200;
                    }

                    return 0;
                };

            var sum = this.components.Sum(getCargoCapacity);
            Assert.AreEqual(ExpectedCargo, sum);
        }
    }
}
