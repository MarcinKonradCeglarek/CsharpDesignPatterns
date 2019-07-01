namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    using System;

    /*
     * https://demos.telerik.com/aspnet-mvc/grid/custom-datasource
     */
    public class CarBuilder
    {
        public Car Build()
        {
            throw new NotImplementedException();
        }

        public CarBuilder AutomaticTransmission()
        {
            throw new NotImplementedException();
        }

        public CarBuilder GasolineEngine()
        {
            throw new NotImplementedException();
        }

        public CarBuilder ManualTransmission()
        {
            /*
             * Can not be used with Electric and Hybird engines
             */
            throw new NotImplementedException();
        }

        public CarBuilder DieselEngine()
        {
            throw new NotImplementedException();
        }

        public CarBuilder ElectricEngine()
        {
            /*
             * Electric engine requires Automatic transmission
             */
            throw new NotImplementedException();
        }

        public CarBuilder HybridEngine()
        {
            /*
             * Electric engine (Hybrid engine is Gasoline and Electric engines duo) requires Automatic Transmission
             */
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