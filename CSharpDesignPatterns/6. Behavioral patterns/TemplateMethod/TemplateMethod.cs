namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class NameFormatterTemplateMethod
    {
        public string GetName()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(this.GetPrefix()))
            {
                sb.Append(this.GetPrefix());
                sb.Append(" ");
            }

            sb.Append(string.Join(" ", this.GetFirstNames().Where(n => !string.IsNullOrEmpty(n))));
            sb.Append(" ");
            sb.Append(this.GetLastName());

            if (!string.IsNullOrEmpty(this.GetSuffix()))
            {
                sb.Append(this.GetSuffix());
            }

            return sb.ToString();
        }

        protected abstract string GetPrefix();

        protected abstract IEnumerable<string> GetFirstNames();

        protected abstract string GetLastName();

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

        protected override string GetPrefix()
        {
            return null;
        }

        protected override IEnumerable<string> GetFirstNames()
        {
            return new[] { this.firstName };
        }

        protected override string GetLastName()
        {
            return this.lastName;
        }

        protected override string GetSuffix()
        {
            return null;
        }
    }

    public class RoyaltyNameFormatter : NameFormatterTemplateMethod
    {
        private readonly string prefix;
        private readonly string firstName;
        private readonly string secondName;
        private readonly string thirdName;
        private readonly string lastName;
        private readonly IEnumerable<string> suffixes;

        public RoyaltyNameFormatter(
            string              prefix,
            string              firstName,
            string              secondName,
            string              thirdName,
            string              lastName,
            IEnumerable<string> suffixes)
        {
            this.prefix = prefix;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.suffixes = suffixes;
        }

        protected override string GetPrefix()
        {
            return this.prefix;
        }

        protected override IEnumerable<string> GetFirstNames()
        {
            return new[] { this.firstName, this.secondName, this.thirdName };
        }

        protected override string GetLastName()
        {
            return $"von {this.lastName} ";
        }

        protected override string GetSuffix()
        {
            return string.Join(", ", this.suffixes);
        }
    }
}