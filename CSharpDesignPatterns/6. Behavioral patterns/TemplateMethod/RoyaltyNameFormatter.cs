namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaltyNameFormatter : NameFormatterTemplateMethod
    {
        private readonly string prefix;
        private readonly string firstName;
        private readonly string secondName;
        private readonly string thirdName;
        private readonly string lastName;

        public RoyaltyNameFormatter(string prefix, string firstName, string secondName, string thirdName, string lastName)
        {
            this.prefix = prefix;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
        }

        protected override IEnumerable<string> GetFirstNames() =>
            new[] { this.firstName, this.secondName, this.thirdName };

        protected override string GetLastName() => $"von {this.lastName}";

        protected override string GetPrefix() => this.prefix;

    }
}