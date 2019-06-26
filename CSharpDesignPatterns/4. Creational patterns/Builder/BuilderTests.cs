namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    using NUnit.Framework;

    public class CarBuilderTests
    {
        [Test]
        public void CarBuilder_DefaultObject()
        {
            var result = new CarBuilder().Build();

            Assert.IsInstanceOf<Car>(result);
            Assert.AreEqual(EngineType.Gasoline,     result.EngineType);
            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
            Assert.AreEqual(4,                       result.Wheels);
        }

        [Test]
        public void CarBuilder_DefaultEngine_CreatesGasolineCar()
        {
            var result = new CarBuilder().ManualTransmission().Build();

            Assert.AreEqual(EngineType.Gasoline,     result.EngineType);
            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
        }

        [Test]
        public void CarBuilder_EngineTypeDiesel_CreatesDieselCar()
        {
            var result = new CarBuilder().DieselEngine().Build();

            Assert.AreEqual(EngineType.Diesel, result.EngineType);
        }

        [Test]
        public void CarBuilder_EngineTypeElectric_CreatesElectricCar()
        {
            var result = new CarBuilder().ElectricEngine().Build();

            Assert.AreEqual(EngineType.Electric,        result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Test]
        public void EngineTypeGasoline_CreatesGasolineCar()
        {
            var result = new CarBuilder().GasolineEngine().Build();

            Assert.AreEqual(EngineType.Gasoline, result.EngineType);
        }

        [Test]
        public void EngineTypeHybrid_CreatesHybridCar()
        {
            var result = new CarBuilder().HybridEngine().Build();

            Assert.AreEqual(EngineType.Hybrid,          result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Test]
        public void EngineTypeElectricManualTransmission_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ManualTransmission().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingGasolineEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().GasolineEngine().GasolineEngine().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingDieselEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().DieselEngine().DieselEngine().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingHybridEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().HybridEngine().HybridEngine().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingElectricEngineTwice_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ElectricEngine().Build());
        }


        [Ignore("Least important")]
        [Test]
        public void AddingManualTransmissionAndThenElectricEngine_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().ElectricEngine().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingManualTransmissionAndThenHybridEngine_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().HybridEngine().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingManualTransmissionTwice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ManualTransmission().ManualTransmission().Build());
        }

        [Ignore("Least important")]
        [Test]
        public void AddingAutomaticTransmissionTwice_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().AutomaticTransmission().AutomaticTransmission().Build());
        }
    }
}