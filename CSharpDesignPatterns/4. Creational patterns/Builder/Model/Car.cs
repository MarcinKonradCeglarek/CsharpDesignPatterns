namespace CSharpDesignPatterns._4._Creational_patterns.Builder.Model
{
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
}