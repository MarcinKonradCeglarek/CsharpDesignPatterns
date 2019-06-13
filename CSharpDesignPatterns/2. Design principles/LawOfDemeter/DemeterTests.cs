namespace CSharpDesignPatterns._2._Design_principles.LawOfDemeter
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    using NUnit.Framework;

    [TestFixture]
    internal class DemeterTests
    {
        private const string NewGender = "NewGender";

        private static readonly Person AlbertWesker = new Person("Albert", "Wesker", "Male", new DateTime(1960, 01, 01));

        private static readonly Person AlexWesker = new Person("Alex", "Wesker", "Female", new DateTime(1960, 01, 01));

        [Test]
        public void X()
        {
            // Arrange
            var company = this.GetCompany();

            // Act
            Demeter.UpdateEmployeeGenderBeginnerWay(company, AlbertWesker.Id, NewGender);

            // Assert
            Assert.AreEqual(NewGender, company.Employees[AlbertWesker.Id].Person.Gender);
        }

        [Test]
        public void Y()
        {
            // Arrange
            var company = this.GetCompany();

            // Act
            Demeter.UpdateEmployeeGenderDemeterWay(company, AlbertWesker.Id, NewGender);

            // Assert
            Assert.AreEqual(NewGender, company.Employees[AlbertWesker.Id].Person.Gender);
        }

        private Company GetCompany()
        {
            var company = new Company("Umbrella Corporation");
            company.Hire(AlbertWesker, "Security officer", 200000);
            company.Hire(AlexWesker,   "Researcher",       200000);
            return company;
        }
    }
}