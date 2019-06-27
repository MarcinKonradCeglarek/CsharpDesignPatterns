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

        [Ignore("Transmission constraint")]
        [Test]
        public void BuildElectricCar()
        {
            var result = new CarBuilder().ElectricEngine().Build();

            Assert.AreEqual(EngineType.Electric,        result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Ignore("Transmission constraint")]
        [Test]
        public void BuildHybridEngineCar()
        {
            var result = new CarBuilder().HybridEngine().Build();

            Assert.AreEqual(EngineType.Hybrid,          result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Ignore("Negative test")]
        [Test]
        public void ThrowsExceptionWhenBuildingElectricEngineWithManualTransmission()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ManualTransmission().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingGasolineEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().GasolineEngine().GasolineEngine().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingDieselEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().DieselEngine().DieselEngine().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingHybridEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().HybridEngine().HybridEngine().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingElectricEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ElectricEngine().Build());
        }


        [Ignore("Exception handling")]
        [Test]
        public void AddingManualTransmissionAndThenElectricEngine_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().ElectricEngine().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingManualTransmissionAndThenHybridEngine_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().HybridEngine().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingManualTransmissionTwice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().ManualTransmission().Build());
        }

        [Ignore("Exception handling")]
        [Test]
        public void AddingAutomaticTransmissionTwice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().AutomaticTransmission().AutomaticTransmission().Build());
        }
    }
}