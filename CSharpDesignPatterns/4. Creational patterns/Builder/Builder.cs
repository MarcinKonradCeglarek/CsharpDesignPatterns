namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    public class CarBuilder
    {
        private EngineType?       engineType;
        private TransmissionType? transmissionType;
        private int?              wheels;

        public CarBuilder AutomaticTransmission()
        {
            throw new NotImplementedException();
        }

        public Car Build()
        {
            throw new NotImplementedException();
        }

        public CarBuilder DieselEngine()
        {
            throw new NotImplementedException();
        }

        public CarBuilder ElectricEngine()
        {
            throw new NotImplementedException();
        }

        public CarBuilder GasolineEngine()
        {
            throw new NotImplementedException();
        }

        public CarBuilder HybridEngine()
        {
            throw new NotImplementedException();
        }

        public CarBuilder ManualTransmission()
        {
            throw new NotImplementedException();
        }
    }

    public class Car
    {
        public Car(EngineType engineType, TransmissionType transmissionType, int wheels)
        {
            this.EngineType       = engineType;
            this.TransmissionType = transmissionType;
            this.Wheels           = wheels;
        }

        public EngineType EngineType { get; }

        public TransmissionType TransmissionType { get; }

        public int Wheels { get; }
    }

    [Flags]
    public enum EngineType
    {
        Diesel   = 1,
        Gasoline = 2,
        Electric = 4,
        Hybrid   = 6
    }

    public enum TransmissionType
    {
        Automatic,
        Manual
    }
}