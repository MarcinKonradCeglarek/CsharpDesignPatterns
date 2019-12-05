namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    public class Bus : IVehicle
    {
        public void Accept(IVehicleVisitor vehicleVisitor)
        {
            vehicleVisitor.Visit(this);
        }
    }
}