namespace CSharpDesignPatterns._2._Design_principles.DryPrinciple.Example
{
    using CSharpDesignPatterns.Common.Model;

    internal static class PersonFormatter
    {
        internal static string Format(Person person)
        {
            return $"{person.Name} {person.LastName}, age {person.Age}";
        }

        internal static string Format(string input)
        {
            return input;
        }
    }
}