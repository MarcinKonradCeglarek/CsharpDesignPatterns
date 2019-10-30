namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    using CSharpDesignPatterns.Common.Helpers;
    using CSharpDesignPatterns.Common.Model;

    using NUnit.Framework;

    [TestFixture]
    public class CompanyGenericTemplateMethodTests
    {
        [Test]
        public void AddingNewEmployee()
        {
            var person  = Generator.GeneratePerson();
            var company = Generator.GenerateCompany();

            var sut = new CompanyGenericTemplateMethod();

            sut.AddToParent(company, new Employee(person, "Title", 15.2));
        }

        [Test]
        public void AddingEmployeeTwiceShouldThrow()
        {
            var person  = Generator.GeneratePerson();
            var company = Generator.GenerateCompany();

            var sut = new CompanyGenericTemplateMethod();

            sut.AddToParent(company, new Employee(person, "Title", 15.2));
            Assert.Throws<InvalidOperationException>(
                () => sut.AddToParent(company, new Employee(person, "Title", 15.2)));
        }

        [Test]
        public void RemoveNotHiredEmployeeShouldThrow()
        {
            var person     = Generator.GeneratePerson();
            var company    = Generator.GenerateCompany();

            var sut = new CompanyGenericTemplateMethod();

            Assert.Throws<InvalidOperationException>(
                () => sut.RemoveFromParent(company, new Employee(person, "Title", 10000)));
        }

        [Test]
        public void ProperlyMovesEmployee()
        {
            var person     = Generator.GeneratePerson();
            var oldCompany = Generator.GenerateCompany();
            var newCompany = Generator.GenerateCompany();
            var employee   = oldCompany.Hire(person, "title", 10000);

            var sut = new CompanyGenericTemplateMethod();

            sut.MoveChildBetweenParents(oldCompany, newCompany, employee);

            Assert.IsTrue(newCompany.IsHired(person.Id));
            Assert.IsFalse(oldCompany.IsHired(person.Id));
        }
    }
}