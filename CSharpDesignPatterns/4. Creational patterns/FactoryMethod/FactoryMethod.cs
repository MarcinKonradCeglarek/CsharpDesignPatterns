﻿namespace CSharpDesignPatterns._4._Creational_patterns.FactoryMethod
{
    using System;

    /*
     * https://refactoring.guru/design-patterns/factory-method
     */
    public static class PeopleFactory
    {
        public static IPerson GetPerson(PersonType type)
        {
            switch (type)
            {
                case PersonType.Rural:
                    return new Villager();
                case PersonType.Urban:
                    return new CityPerson();
                default:
                    throw new NotSupportedException();
            }
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