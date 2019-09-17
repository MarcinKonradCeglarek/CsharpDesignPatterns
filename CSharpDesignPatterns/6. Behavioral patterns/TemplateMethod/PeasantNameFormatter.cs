namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Collections.Generic;

    public class PeasantNameFormatter : NameFormatterTemplateMethod
    {
        public PeasantNameFormatter(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> GetFirstNames() => throw new NotImplementedException();

        protected override string GetLastName() => throw new NotImplementedException();

        protected override string GetPrefix() => throw new NotImplementedException();
    }
}