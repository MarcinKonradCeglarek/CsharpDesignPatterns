namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using NUnit.Framework;

    [TestFixture]
    public class NameFormatterTemplateMethodTests
    {
        [Test]
        public void PeasantFormatter()
        {
            const string FirstName = "Poor";
            const string LastName  = "Peasant";

            var formatter = new PeasantNameFormatter(FirstName, LastName);

            Assert.AreEqual("Poor Peasant", formatter.GetName());
        }

        [Test]
        public void RoyaltyFormatterWithAllPossibleNames()
        {
            var firstName  = "Gregory";
            var secondName = "Peter";
            var thirdName  = "Andrew";
            var lastName   = "Bailish";

            var formatter = new RoyaltyNameFormatter("sir", firstName, secondName, thirdName, lastName);

            Assert.AreEqual($"sir {firstName} {secondName} {thirdName} von {lastName}", formatter.GetName());
        }

        [Test]
        public void RoyaltyFormatterWithAllExceptSecondName()
        {
            var firstName = "Gregory";
            var thirdName = "Andrew";
            var lastName  = "Bailish";

            var formatter = new RoyaltyNameFormatter("sir", firstName, null, thirdName, lastName);

            Assert.AreEqual($"sir {firstName} {thirdName} von {lastName}", formatter.GetName());
        }

        [Test]
        public void RoyaltyFormatterWithJustFirstAndLastName()
        {
            const string FirstName = "Poor";
            const string LastName  = "Peasant";

            var formatter = new RoyaltyNameFormatter(null, FirstName, null, null, LastName);

            Assert.AreEqual($"{FirstName} von {LastName}", formatter.GetName());
        }
    }
}