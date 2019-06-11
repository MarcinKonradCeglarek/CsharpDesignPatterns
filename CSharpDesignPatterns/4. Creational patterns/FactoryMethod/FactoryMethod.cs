namespace CSharpDesignPatterns._4._Creational_patterns.FactoryMethod
{
    using System;

    internal static class PeopleFactory
    {
        public static IPerson GetPerson(PersonType type)
        {
            switch (type)
            {
                case PersonType.Urban:
                    return new CityPerson();
                case PersonType.Rural:
                    return new Villager();
            }

            throw new NotSupportedException();
        }
    }

    internal interface IPerson
    {
        string Occupation { get; }
    }

    internal class Villager : IPerson
    {
        public string Occupation => "Farmer";
    }

    internal class CityPerson : IPerson
    {
        public string Occupation => "Clerk";
    }

    internal enum PersonType
    {
        None,
        Rural,
        Urban
    }
}