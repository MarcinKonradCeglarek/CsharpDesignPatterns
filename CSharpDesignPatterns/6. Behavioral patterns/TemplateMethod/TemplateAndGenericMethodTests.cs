namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    using CSharpDesignPatterns.Common.Helpers;
    using CSharpDesignPatterns.Common.Model;

    using NUnit.Framework;

    [TestFixture]
    public class TemplateAndGenericMethodTests
    {
        [Test]
        public void ProperlyMovesEmployee()
        {
            var person     = Generator.GeneratePerson();
            var oldCompany = Generator.GenerateCompany();
            var newCompany = Generator.GenerateCompany();
            var employee   = oldCompany.Hire(person, "title", 10000);

            var sut = new CompanyManager();

            sut.ChangeParent(employee, oldCompany, newCompany);

            Assert.IsTrue(newCompany.IsHired(person.Id));
            Assert.IsFalse(oldCompany.IsHired(person.Id));
        }

        [Test]
        public void RemoveEmployeeNotHiredShouldThrowException()
        {
            var person     = Generator.GeneratePerson();
            var company    = Generator.GenerateCompany();
            var newCompany = Generator.GenerateCompany();

            var sut = new CompanyManager();

            Assert.Throws<InvalidOperationException>(() => sut.ChangeParent(new Employee(newCompany, person, "Title", 10000), company, newCompany));
        }
    }
}