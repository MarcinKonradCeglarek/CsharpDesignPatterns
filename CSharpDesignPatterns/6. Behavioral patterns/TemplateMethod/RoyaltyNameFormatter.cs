﻿namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Collections.Generic;

    public class RoyaltyNameFormatter : NameFormatterTemplateMethod
    {

        public RoyaltyNameFormatter(string prefix, string firstName, string secondName, string thirdName, string lastName)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> GetFirstNames() => throw new NotImplementedException();

        protected override string GetLastName() => throw new NotImplementedException();

        protected override string GetPrefix() => throw new NotImplementedException();

    }
}