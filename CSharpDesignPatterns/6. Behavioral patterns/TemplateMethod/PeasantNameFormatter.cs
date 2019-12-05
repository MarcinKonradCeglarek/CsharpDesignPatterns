namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;

    public class PeasantNameFormatter : NameFormatterTemplateMethod
    {
        private readonly string firstName;
        private readonly string lastName;

        public PeasantNameFormatter(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName  = lastName;
        }

        protected override IEnumerable<string> GetFirstNames() => new[] { this.firstName };

        protected override string GetLastName() => this.lastName;

        protected override string GetPrefix() => null;
    }
}