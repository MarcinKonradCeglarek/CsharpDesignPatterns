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
            Assert.AreEqual(EngineType.Gasoline, result.EngineType);
            Assert.AreEqual(TransmissionType.Manual, result.TransmissionType);
            Assert.AreEqual(4, result.Wheels);
        }

        [Test]
        public void CarBuilder_DefaultEngine_CreatesGasolineCar()
        {
            var result = new CarBuilder().Build();

            Assert.AreEqual(EngineType.Gasoline, result.EngineType);
        }

        [Test]
        public void CarBuilder_EngineTypeGasoline_CreatesGasolineCar()
        {
            var result = new CarBuilder().GasolineEngine().Build();

            Assert.AreEqual(EngineType.Gasoline, result.EngineType);
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

            Assert.AreEqual(EngineType.Electric, result.EngineType);
            Assert.AreEqual(TransmissionType.Automatic, result.TransmissionType);
        }

        [Test]
        public void CarBuilder_EngineTypeElectricManualTransmission_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new CarBuilder().ElectricEngine().ManualTransmission().Build());
        }
    }
}