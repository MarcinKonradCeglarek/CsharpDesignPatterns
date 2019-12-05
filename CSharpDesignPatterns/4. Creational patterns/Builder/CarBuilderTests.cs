namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    using CSharpDesignPatterns._4._Creational_patterns.Builder.Model;

    using NUnit.Framework;

    public class CarBuilderTests
    {
        [Test]
        public void BuildDefault()
        {
            var result = new CarBuilder().Build();

            Assert.IsInstanceOf<Car>(result);
            Assert.AreEqual(EngineType.Gasoline,     result.EngineType);
            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
            Assert.AreEqual(4,                       result.Wheels);
        }

        [Test]
        public void BuildGasolineCar()
        {
            var result = new CarBuilder().GasolineEngine().Build();

            Assert.AreEqual(EngineType.Gasoline, result.EngineType);
        }

        [Test]
        public void BuildDieselEngineCar()
        {
            var result = new CarBuilder().DieselEngine().Build();

            Assert.AreEqual(EngineType.Diesel, result.EngineType);
        }

        [Test]
        public void BuildElectricCar()
        {
            var result = new CarBuilder().ElectricEngine().Build();

            Assert.AreEqual(EngineType.Electric,        result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Test]
        public void BuildHybridEngineCar()
        {
            var result = new CarBuilder().HybridEngine().Build();

            Assert.AreEqual(EngineType.Hybrid,          result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Test]
        public void BuildManualTransmissionCar()
        {
            var result = new CarBuilder().ManualTransmission().Build();

            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
        }

        [Test]
        public void BuildAutomaticTransmissionCar()
        {
            var result = new CarBuilder().AutomaticTransmission().Build();

            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Test]
        public void AddingAutomaticTransmissionTwiceThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => new CarBuilder().AutomaticTransmission().AutomaticTransmission().Build());
        }

        [Test]
        public void AddingDieselEngineTwiceThrows()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().DieselEngine().DieselEngine().Build());
        }

        [Test]
        public void AddingElectricEngineTwiceThrows()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ElectricEngine().Build());
        }

        [Test]
        public void AddingGasolineEngineTwiceThrows()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().GasolineEngine().GasolineEngine().Build());
        }

        [Test]
        public void AddingHybridEngineTwiceThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().HybridEngine().HybridEngine().Build());
        }

        [Test]
        public void AddingManualTransmissionAndThenElectricEngineThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => new CarBuilder().ManualTransmission().ElectricEngine().Build());
        }

        [Test]
        public void AddingManualTransmissionAndThenHybridEngineThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => new CarBuilder().ManualTransmission().HybridEngine().Build());
        }

        [Test]
        public void AddingManualTransmissionTwiceThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => new CarBuilder().ManualTransmission().ManualTransmission().Build());
        }

        [Test]
        public void ElectricEngineWithManualTransmissionThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => new CarBuilder().ElectricEngine().ManualTransmission().Build());
        }

        [Test]
        public void AlternativelyBuildCarWithSixWheels()
        {
            var car = new Car(wheels: 6, engineType: EngineType.Electric);

            Assert.AreEqual(6, car.Wheels);
        }
    }
}