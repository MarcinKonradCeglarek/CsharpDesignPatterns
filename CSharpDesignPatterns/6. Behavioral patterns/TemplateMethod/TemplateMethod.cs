namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /*
     * AKA Workflow
     */

    public abstract class NameFormatterTemplateMethod
    {
        public string GetName()
        {
            throw new NotImplementedException();
        }

        protected abstract IEnumerable<string> GetFirstNames();

        protected abstract string GetLastName();

        protected abstract string GetPrefix();

        protected abstract string GetSuffix();
    }

    public class PeasantNameFormatter : NameFormatterTemplateMethod
    {
        public PeasantNameFormatter(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> GetFirstNames()
        {
            throw new NotImplementedException();
        }

        protected override string GetLastName()
        {
            throw new NotImplementedException();
        }

        protected override string GetPrefix()
        {
            throw new NotImplementedException();
        }

        protected override string GetSuffix()
        {
            throw new NotImplementedException();
        }
    }

    public class RoyaltyNameFormatter : NameFormatterTemplateMethod
    {
        public RoyaltyNameFormatter(string prefix, string firstName, string secondName, string thirdName, string lastName, IEnumerable<string> suffixes)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> GetFirstNames()
        {
            throw new NotImplementedException();
        }

        protected override string GetLastName()
        {
            throw new NotImplementedException();
        }

        protected override string GetPrefix()
        {
            throw new NotImplementedException();
        }

        protected override string GetSuffix()
        {
            throw new NotImplementedException();
        }
    }
}