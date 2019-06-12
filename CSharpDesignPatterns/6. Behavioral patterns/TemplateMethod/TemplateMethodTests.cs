namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using NUnit.Framework;

    [TestFixture]
    public class TemplateMethodTests
    {
        [Test]
        public void PesantsFormatter_FirstAndLastName_ProperlyFormatsHisName()
        {
            const string firstName = "Poor";
            const string lastName  = "Peasant";

            var formatter = new PeasantNameFormatter(firstName, lastName);

            Assert.AreEqual("Poor Peasant", formatter.GetName());
        }

        [Test]
        public void RoyaltyFormatter_AllPossibleNames_ProperlyFormatsHisName()
        {
            var firstName  = "Gregory";
            var secondName = "Peter";
            var thirdName  = "Andrew";
            var lastName   = "Bailish";
            var suffix     = new[] { "the third", "king of Andals" };

            var formatter = new RoyaltyNameFormatter("sir", firstName, secondName, thirdName, lastName, suffix);

            Assert.AreEqual(
                $"sir {firstName} {secondName} {thirdName} von {lastName} {suffix[0]}, {suffix[1]}",
                formatter.GetName());
        }
    }
}