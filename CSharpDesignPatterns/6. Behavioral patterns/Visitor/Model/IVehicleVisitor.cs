namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor.Model
{
    public interface IVehicleVisitor
    {
        void Visit(Car   car);
        void Visit(Truck truck);
        void Visit(Bus   bus);
    }
}