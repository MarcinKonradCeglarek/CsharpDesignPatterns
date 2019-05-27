namespace CSharpDesignPatterns._2._Design_principles.DryPrinciple
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    using NUnit.Framework;

    [TestFixture]
    internal class DryTests
    {
        [Test]
        internal void CheckEligibilityAndFormatEmailHeader_NotEligiblePerson_ReturnsValidFormattedHeader()
        {
            // Arrange
            var person = new Person("Mark", "Bennet", "Male", new DateTime(1999, 03, 15));

            // Act
            var result = Dry.CheckEligibilityAndFormatEmailHeader(person);

            // Assert
            Assert.AreEqual($"Mark Bennet, age 20", result);
        }


        [Test]
        internal void CheckEligibilityAndFormatEmailHeader_EligiblePerson_ReturnsValidFormattedHeader()
        {
            // Arrange
            var person = new Person("Mark", "Bennet", "Male", DateTime.Now.AddYears(-18));

            // Act
            var result = Dry.CheckEligibilityAndFormatEmailHeader(person);

            // Assert
            Assert.AreEqual($"Mark Bennet, age 18", result);
        }
    }
}