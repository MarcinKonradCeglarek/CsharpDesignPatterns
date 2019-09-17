namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    public interface IVehicle
    {
        void Accept(IVehicleVisitor vehicleVisitor);
    }
}
