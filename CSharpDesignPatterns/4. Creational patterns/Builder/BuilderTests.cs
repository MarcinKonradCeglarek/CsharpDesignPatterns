namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    using NUnit.Framework;

    public class CarBuilderTests
    {
        [Test]
        public void DefaultObject()
        {
            var result = new CarBuilder().Build();

            Assert.IsInstanceOf<Car>(result);
            Assert.AreEqual(EngineType.Gasoline,     result.EngineType);
            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
            Assert.AreEqual(4,                       result.Wheels);
        }

        [Test]
        public void WithJustManualTransmissionCreatesGasolineCar()
        {
            var result = new CarBuilder().ManualTransmission().Build();

            Assert.AreEqual(EngineType.Gasoline,     result.EngineType);
            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
        }

        [Test]
        public void BuildDieselEngineCar()
        {
            var result = new CarBuilder().DieselEngine().Build();

            Assert.AreEqual(EngineType.Diesel, result.EngineType);
        }

        [Test]
        public void BuildGasolineCar()
        {
            var result = new CarBuilder().GasolineEngine().Build();

            Assert.AreEqual(EngineType.Gasoline, result.EngineType);
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
        public void ThrowsExceptionWhenBuildingElectricEngineWithManualTransmission()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ManualTransmission().Build());
        }

        [Test]
        public void AddingGasolineEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().GasolineEngine().GasolineEngine().Build());
        }

        [Test]
        public void AddingDieselEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().DieselEngine().DieselEngine().Build());
        }

        [Test]
        public void AddingHybridEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().HybridEngine().HybridEngine().Build());
        }

        [Test]
        public void AddingElectricEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ElectricEngine().Build());
        }

        [Test]
        public void AddingManualTransmissionAndThenElectricEngine_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().ElectricEngine().Build());
        }

        [Test]
        public void AddingManualTransmissionAndThenHybridEngine_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().HybridEngine().Build());
        }

        [Test]
        public void AddingManualTransmissionTwice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().ManualTransmission().Build());
        }

        [Test]
        public void AddingAutomaticTransmissionTwice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().AutomaticTransmission().AutomaticTransmission().Build());
        }
    }
}