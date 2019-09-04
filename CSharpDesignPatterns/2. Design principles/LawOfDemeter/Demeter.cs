namespace CSharpDesignPatterns._2._Design_principles.LawOfDemeter
{
    using System;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    internal class Demeter
    {
        /*
         * Law of Demeter
         *
         * "Each unit should have only limited knowledge about other units: only units "closely" related to the current unit."
         *
         * Each method M within class C can only invoke:
         * - this (object of class C) and each components of this
         * - objects created/instantiated by M and parameters of M
         *
         *
         * Advantages:
         * - software tends to be more maintainable and adaptable
         *
         * Disadvantages:
         * - spaghetti code
         * - requires introducing many auxiliary methods
         */
        public static void UpdateEmployeeGenderBeginnerWay(Company company, Guid id, string newName)
        {
            company.Employees[id].Person.UpdateGender(newName);
        }

        public static void UpdateEmployeeGenderDemeterWay(Company company, Guid id, string newGender)
        {
            company.UpdateEmployeeGender(id, newGender);
        }


        public void DoesThisLinqFollowTheDemeterLaw()
        {
            var result = Enumerable.Range(0, 100)
                                   .Select(i => DateTime.Now.AddDays(i))
                                   .GroupBy(d => d.DayOfWeek)
                                   .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}