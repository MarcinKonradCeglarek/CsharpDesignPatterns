namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    using CSharpDesignPatterns._4._Creational_patterns.Builder.Model;

    /*
     * https://refactoring.guru/design-patterns/builder
     *
     * Great example: https://demos.telerik.com/aspnet-mvc/grid/custom-datasource
     */
    public class CarBuilder
    {
        private EngineType?       engineType;
        private TransmissionType? transmissionType;
        private int?              wheels;

        public Car Build()
        {
            return new Car(
                this.engineType       ?? EngineType.Gasoline,
                this.transmissionType ?? TransmissionType.Manual,
                this.wheels           ?? 4);
        }

        public CarBuilder GasolineEngine()
        {
            /*
             * If already set
             *    throw InvalidOperationException
             *
             * set engineType
             * return builder
             */
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.engineType = EngineType.Gasoline;
            return this;
        }

        public CarBuilder DieselEngine()
        {
            /*
             * If already set
             *    throw InvalidOperationException
             * 
             * set engineType
             *
             * return builder
             */
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
             * If already set
             *    throw InvalidOperationException
             *
             * if transmissionType is set to manual
             *    throw InvalidOperationException
             *
             * set engineType
             * set transmissionType
             *
             * return builder
             */
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            if (this.transmissionType == TransmissionType.Manual)
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
             * If already set
             *    throw InvalidOperationException
             *
             * if transmissionType is set to manual
             *    throw InvalidOperationException
             *
             * set engineType
             * set transmissionType
             *
             * return builder
             */
            if (this.engineType.HasValue)
            {
                throw new InvalidOperationException();
            }

            if (this.transmissionType == TransmissionType.Manual)
            {
                throw new InvalidOperationException();
            }

            this.engineType       = EngineType.Hybrid;
            this.transmissionType = TransmissionType.Automatic;
            return this;
        }

        public CarBuilder ManualTransmission()
        {
            /*
             * Can not be used with Electric and Hybird engines
             *
             * If already set
             *    throw InvalidOperationException
             *
             * set transmissionType
             *
             * return builder
             */
            if (this.transmissionType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.transmissionType = TransmissionType.Manual;
            return this;
        }

        public CarBuilder AutomaticTransmission()
        {
            /*
             * If already set
             *    throw InvalidOperationException
             * 
             * set transmissionType
             *
             * return builder
             */
            if (this.transmissionType.HasValue)
            {
                throw new InvalidOperationException();
            }

            this.transmissionType = TransmissionType.Automatic;
            return this;
        }
    }
}