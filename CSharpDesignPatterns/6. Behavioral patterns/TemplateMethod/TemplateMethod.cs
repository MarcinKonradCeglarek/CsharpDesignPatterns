namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;
    using System.Linq;

    /*
     * https://refactoring.guru/design-patterns/template-method
     *
     * NameFormatterTemplateMethod provides template and abstract methods
     *
     * PeasantNameFormatter and RoyaltyNameFormatter provides implementation for abstract methods
     */

    public abstract class NameFormatterTemplateMethod
    {
        public string GetName()
        {
            var fields = new List<string>() { this.GetPrefix() };
            fields.AddRange(this.GetFirstNames());
            
            fields.Add(this.GetLastName());
            if (this.GetSuffix() != null)
            {
                fields.Add(this.GetSuffix());
            }
            
            return string.Join(" ", fields.Where(f => !string.IsNullOrEmpty(f)));
        }

        protected abstract IEnumerable<string> GetFirstNames();

        protected abstract string GetLastName();

        protected abstract string GetPrefix();

        protected abstract string GetSuffix();
    }

    public class PeasantNameFormatter : NameFormatterTemplateMethod
    {
        private readonly string firstName;
        private readonly string lastName;

        public PeasantNameFormatter(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        protected override IEnumerable<string> GetFirstNames() => new[] { this.firstName };

        protected override string GetLastName() => this.lastName;

        protected override string GetPrefix() => null;

        protected override string GetSuffix() => null;
    }

    public class RoyaltyNameFormatter : NameFormatterTemplateMethod
    {
        private readonly string prefix;
        private readonly string firstName;
        private readonly string secondName;
        private readonly string thirdName;
        private readonly string lastName;
        private readonly IEnumerable<string> suffixes;

        public RoyaltyNameFormatter(string prefix, string firstName, string secondName, string thirdName, string lastName, IEnumerable<string> suffixes)
        {
            this.prefix = prefix;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.suffixes = suffixes;
        }

        protected override IEnumerable<string> GetFirstNames() => new[] { this.firstName, this.secondName, this.thirdName }.Where(s => !string.IsNullOrEmpty(s));

        protected override string GetLastName() => $"von {this.lastName}";

        protected override string GetPrefix() => this.prefix;

        protected override string GetSuffix() => this.suffixes != null ? string.Join(", ", this.suffixes) : null;
    }
}