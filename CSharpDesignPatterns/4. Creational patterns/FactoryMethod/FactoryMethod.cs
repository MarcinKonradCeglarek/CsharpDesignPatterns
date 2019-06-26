namespace CSharpDesignPatterns._4._Creational_patterns.FactoryMethod
{
    using System;

    public static class PeopleFactory
    {
        public static IPerson GetPerson(PersonType type)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPerson
    {
        string Occupation { get; }
    }

    public class Villager : IPerson
    {
        public string Occupation => "Farmer";
    }

    public class CityPerson : IPerson
    {
        public string Occupation => "Clerk";
    }

    public enum PersonType
    {
        None,
        Rural,
        Urban
    }
}