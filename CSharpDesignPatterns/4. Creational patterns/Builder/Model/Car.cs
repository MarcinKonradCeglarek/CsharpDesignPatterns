namespace CSharpDesignPatterns._4._Creational_patterns.Builder.Model
{
    public class Car
    {
        public Car(
            EngineType       engineType       = EngineType.Gasoline,
            TransmissionType transmissionType = TransmissionType.Manual,
            int              wheels           = 4)
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