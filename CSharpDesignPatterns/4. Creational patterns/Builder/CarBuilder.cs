namespace CSharpDesignPatterns._4._Creational_patterns.Builder
{
    internal class CarBuilder
    {
        private EngineType engineType = EngineType.Gasoline;

        private TransmissionType transmissionType = TransmissionType.Manual;

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

    public enum EngineType
    {
        Diesel,
        Gasoline,
        Electric
    }

    public enum TransmissionType
    {
        Automatic,
        Manual
    }
}