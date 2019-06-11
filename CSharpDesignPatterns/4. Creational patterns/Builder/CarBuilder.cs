namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    internal class CarBuilder
    {
        private EngineType?       engineType;
        private TransmissionType? transmissionType;
        private int?              wheels;

        public CarBuilder AutomaticTransmission()
        {
            if (this.transmissionType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.transmissionType = TransmissionType.Automatic;
            return this;
        }

        public Car Build()
        {
            return new Car(this.engineType ?? EngineType.Gasoline, this.transmissionType ?? TransmissionType.Manual, this.wheels ?? 4);
        }

        public CarBuilder DieselEngine()
        {
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.engineType = EngineType.Diesel;
            return this;
        }

        public CarBuilder ElectricEngine()
        {
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            if (this.transmissionType.HasValue && this.transmissionType.Value == TransmissionType.Manual)
            {
                throw new InvalidOperationException();
            }

            this.engineType       = EngineType.Electric;
            this.transmissionType = TransmissionType.Automatic;
            return this;
        }

        public CarBuilder GasolineEngine()
        {
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.engineType = EngineType.Gasoline;
            return this;
        }

        public CarBuilder HybridEngine()
        {
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            if (this.transmissionType.HasValue && this.transmissionType.Value == TransmissionType.Manual)
            {
                throw new InvalidOperationException();
            }

            this.engineType       = EngineType.Hybrid;
            this.transmissionType = TransmissionType.Automatic;
            return this;
        }

        public CarBuilder ManualTransmission()
        {
            if (this.transmissionType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.transmissionType = TransmissionType.Manual;
            return this;
        }
    }

    internal class Car
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