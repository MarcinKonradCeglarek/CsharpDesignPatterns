namespace CSharpDesignPatterns._2._Design_principles.DryPrinciple
{
    using System;

    using CSharpDesignPatterns.Common.Model;
    using CSharpDesignPatterns._2._Design_principles.DryPrinciple.Helpers;

    public class Dry
    {
        /*
         * Don't Repeat Yourself
         *
         * "Every piece of knowledge must have a single, unambiguous, authoritative representation within a system"
         *
         * Good examples: Work flows, Objects/exceptions formatting, utility methods, Template methods/LINQ
         * 
         */
        public static string CheckEligibilityAndFormatEmailHeader(Person person)
        {
            if (person.BirthDate.Date == DateTime.Now.AddYears(-18).Date)
            {
                return MarkEligibility(person);
            }

            return PersonFormatter.Format(person);
        }

        private static string MarkEligibility(Person person)
        {
            // TODO: Mark Eligibility in some db or system
            return PersonFormatter.Format(person.ToString());
        }
    }
}