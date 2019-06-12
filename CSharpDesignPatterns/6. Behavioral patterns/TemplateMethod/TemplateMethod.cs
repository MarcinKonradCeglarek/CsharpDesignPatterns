namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class NameFormatterTemplateMethod
    {
        public string GetName()
        {
            throw new System.NotImplementedException();
        }

        protected abstract string GetPrefix();

        protected abstract IEnumerable<string> GetFirstNames();

        protected abstract string GetLastName();

        protected abstract string GetSuffix();
    }

    public class PeasantNameFormatter : NameFormatterTemplateMethod
    {
        public PeasantNameFormatter(string firstName, string LastName)
        {
        }

        protected override string GetPrefix()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<string> GetFirstNames()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetLastName()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetSuffix()
        {
            throw new System.NotImplementedException();
        }
    }

    public class RoyaltyNameFormatter : NameFormatterTemplateMethod
    {
        public RoyaltyNameFormatter(
            string              prefix,
            string              firstName,
            string              secondName,
            string              thirdName,
            string              LastName,
            IEnumerable<string> suffixes)
        {

        }

        protected override string GetPrefix()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<string> GetFirstNames()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetLastName()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetSuffix()
        {
            throw new System.NotImplementedException();
        }
    }
}