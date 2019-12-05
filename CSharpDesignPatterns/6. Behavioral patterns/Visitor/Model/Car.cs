namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    public class Car : IVehicle
    {
        public Car(int seats)
        {
            this.Passengers = seats - 1;
        }

        public int Passengers { get; }

        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            vehicleVisitor.Visit(this);
        }
    }
}