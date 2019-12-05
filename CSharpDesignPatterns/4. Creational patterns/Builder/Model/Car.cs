namespace CSharpDesignPatterns._4._Creational_patterns.Builder.Model
{
    using System;

    public class Car
    {
        public Car(
            EngineType       engineType       = EngineType.Gasoline,
            TransmissionType transmissionType = TransmissionType.Manual,
            int              wheels           = 4)
        {
            if ((engineType == EngineType.Electric || engineType == EngineType.Hybrid)
                && (transmissionType == TransmissionType.Manual))
            {
                throw new InvalidOperationException("Can't use Manual Transmission with Electric or Hybrid engines");
            }

            if (wheels % 2 != 0)
            {
                throw new InvalidOperationException("Number of wheels needs to be even");
            }

            this.EngineType       = engineType;
            this.TransmissionType = transmissionType;
            this.Wheels           = wheels;
        }

        public EngineType EngineType { get; }

        public TransmissionType TransmissionType { get; }

        public int Wheels { get; }
    }
}