namespace CSharpDesignPatterns.Common.Helpers
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    internal static class Generator
    {
        private static readonly string[] Companies   = { "Royal Ditch Oyster", "PB", "SaxxonModil", "Pear", "Jungler" };
        private static readonly string[] FemaleNames = { "Chloe", "Emily", "Emma", "Aaliyah", "Olivia", "Lauren" };
        private static readonly string[] MaleNames   = { "Jacob", "Michael", "Aaron", "Shawn", "Daniel", "Alex" };
        private static readonly Random   Random      = new Random();

        private static readonly string[] Surnames =
            {
                "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller"
            };

        internal static Company GenerateCompany()
        {
            return new Company(GetRandomValue(Companies));
        }

        internal static Person GeneratePerson()
        {
            var isMale = Random.Next(2) == 1;

            return new Person(
                isMale ? GetRandomValue(MaleNames) : GetRandomValue(FemaleNames),
                GetRandomValue(Surnames),
                isMale ? "Male" : "Female",
                new DateTime(2019 - Random.Next(75), Random.Next(1, 12), Random.Next(1, 28)));
        }

        private static string GetRandomValue(string[] input)
        {
            var value = Random.Next(input.Length);
            return input[value];
        }
    }
}