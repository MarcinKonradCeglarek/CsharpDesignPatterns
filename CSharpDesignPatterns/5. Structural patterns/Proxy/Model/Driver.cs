namespace CSharpDesignPatterns._5._Structural_patterns.Proxy.Model
{
    public class Driver
    {
        public Driver(int age, bool hasDrivingLicense)
        {
            this.Age               = age;
            this.HasDrivingLicense = hasDrivingLicense;
        }

        public int  Age               { get; }
        public bool HasDrivingLicense { get; }
    }
}