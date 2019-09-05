namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    /*
     * https://refactoring.guru/design-patterns/builder
     *
     * Great example: https://demos.telerik.com/aspnet-mvc/grid/custom-datasource
     */
    public class CarBuilder
    {
        private int? wheelsCount;
        private TransmissionType? transmissionType;
        private EngineType? engineType;

        public Car Build()
        {
            return new Car(
                this.engineType       ?? EngineType.Gasoline,
                this.transmissionType ?? TransmissionType.Manual,
                this.wheelsCount      ?? 4);
        }

        public CarBuilder AutomaticTransmission()
        {
            if (this.transmissionType.HasValue)
            {
                throw new InvalidOperationException();
            }

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

        public CarBuilder ManualTransmission()
        {
            /*
             * Can not be used with Electric and Hybird engines
             */
            if (this.transmissionType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.transmissionType = TransmissionType.Manual;
            return this;
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
            /*
             * Electric engine requires Automatic transmission
             */
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            if (this.transmissionType.HasValue && this.transmissionType == TransmissionType.Manual)
            {
                throw new InvalidOperationException();
            }

            this.engineType = EngineType.Electric;
            this.transmissionType = TransmissionType.Automatic;
            return this;
        }

        public CarBuilder HybridEngine()
        {
            /*
             * Electric engine (Hybrid engine is Gasoline and Electric engines duo) requires Automatic Transmission
             */
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            if (this.transmissionType.HasValue && this.transmissionType == TransmissionType.Manual)
            {
                throw new InvalidOperationException();
            }

            this.engineType       = EngineType.Hybrid;
            this.transmissionType = TransmissionType.Automatic;
            return this;
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