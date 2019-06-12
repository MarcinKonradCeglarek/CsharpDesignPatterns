namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void DaysIterator_AllDays_ProperNumberOfDays()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual(7, sut.Count());
        }

        [Test]
        public void DaysIterator_FirstDay_Monday()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual("Monday", sut.First());
        }

        [Test]
        public void DaysIterator_LastDay_Sunday()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual("Sunday", sut.Last());
        }
    }
}