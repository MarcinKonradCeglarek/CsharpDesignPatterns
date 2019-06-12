namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using NUnit.Framework;

    [TestFixture]
    public class TemplateMethodTests
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
        public void RoyaltyFormatterWithAllExceptSecondName()
        {
            var firstName = "Gregory";
            var thirdName = "Andrew";
            var lastName  = "Bailish";
            var suffix    = new[] { "the third", "king of Andals" };

            var formatter = new RoyaltyNameFormatter("sir", firstName, null, thirdName, lastName, suffix);

            Assert.AreEqual($"sir {firstName} {thirdName} von {lastName} {suffix[0]}, {suffix[1]}", formatter.GetName());
        }

        [Test]
        public void RoyaltyFormatterWithAllPossibleNames()
        {
            var firstName  = "Gregory";
            var secondName = "Peter";
            var thirdName  = "Andrew";
            var lastName   = "Bailish";
            var suffix     = new[] { "the third", "king of Andals" };

            var formatter = new RoyaltyNameFormatter("sir", firstName, secondName, thirdName, lastName, suffix);

            Assert.AreEqual($"sir {firstName} {secondName} {thirdName} von {lastName} {suffix[0]}, {suffix[1]}", formatter.GetName());
        }

        [Test]
        public void RoyaltyFormatterWithJustFirstAndLastName()
        {
            const string FirstName = "Poor";
            const string LastName  = "Peasant";

            var formatter = new RoyaltyNameFormatter(null, FirstName, null, null, LastName, null);

            Assert.AreEqual($"{FirstName} von {LastName}", formatter.GetName());
        }
    }
}