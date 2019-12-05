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
            throw new NotImplementedException();
        }

        public Car Build()
        {
            throw new NotImplementedException();
        }

        public CarBuilder DieselEngine()
        {
            /*
             * If engineType already set
             *    throw InvalidOperationException
             * 
             * set engineType
             *
             * return builder
             */
            throw new NotImplementedException();
        }

        public CarBuilder ElectricEngine()
        {
            /*
             * If engineType already set
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
            throw new NotImplementedException();
        }

        public CarBuilder GasolineEngine()
        {
            /*
             * If engineType already set
             *    throw InvalidOperationException
             *
             * set engineType
             * return builder
             */
            throw new NotImplementedException();
        }

        public CarBuilder HybridEngine()
        {
            /*
             * If engineType already set
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
            throw new NotImplementedException();
        }

        public CarBuilder ManualTransmission()
        {
            /*
             * Can not be used with Electric and Hybrid engines
             *
             * If already set
             *    throw InvalidOperationException
             *
             * set transmissionType
             *
             * return builder
             */
            throw new NotImplementedException();
        }
    }
}