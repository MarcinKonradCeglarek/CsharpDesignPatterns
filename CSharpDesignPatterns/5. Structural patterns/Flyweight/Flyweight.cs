namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System.Linq;

    class Flyweight
    {
    }

    public class CoffeeFlavour
    {
        public CoffeeFlavour(string flavour)
        {
            this.Flavour = flavour;
            this.Data = string.Join("-#-", Enumerable.Range(0, 100).Select(i => flavour));
        }

        public string Data { get; set; }

        public string Flavour { get; }

        public static bool operator ==(CoffeeFlavour a, CoffeeFlavour b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(CoffeeFlavour a, CoffeeFlavour b)
        {
            return !Equals(a, b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CoffeeFlavour flavour && Equals(flavour);
        }

        public bool Equals(CoffeeFlavour other)
        {
            return string.Equals(this.Flavour, other.Flavour);
        }

        public override int GetHashCode()
        {
            return this.Flavour.GetHashCode();
        }
    }
}