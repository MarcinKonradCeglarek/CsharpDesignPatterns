namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    internal class CarBuilder
    {
        private EngineType? engineType;

        private TransmissionType? transmissionType;

        private int wheels = 4;

        public Car Build()
        {
            throw new System.NotImplementedException();
        }

        public CarBuilder DieselEngine()
        {
            throw new System.NotImplementedException();
        }

        public CarBuilder GasolineEngine()
        {
            throw new System.NotImplementedException();
        }

        public CarBuilder ElectricEngine()
        {
            throw new System.NotImplementedException();
        }

        public CarBuilder HybridEngine()
        {
            throw new System.NotImplementedException();
        }

        public CarBuilder ManualTransmission()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class Car
    {
        public Car(EngineType engineType, TransmissionType transmissionType, int wheels)
        {
            this.EngineType = engineType;
            this.TransmissionType = transmissionType;
            this.Wheels = wheels;
        }

        public EngineType EngineType { get; }

        public TransmissionType TransmissionType { get; }

        public int Wheels { get; }
    }

    [Flags]
    public enum EngineType
    {
        Diesel = 1,
        Gasoline = 2,
        Electric = 4,
        Hybrid = 6
    }

    public enum TransmissionType
    {
        Automatic,
        Manual
    }
}