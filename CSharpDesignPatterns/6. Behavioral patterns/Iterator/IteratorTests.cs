namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void FirstDayIsMonday()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual("Monday", sut.First());
        }

        [Test]
        public void LastDayIsSunday()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual("Sunday", sut.Last());
        }

        [Test]
        public void ThereIs7DaysInWeek()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual(7, sut.Count());
        }
    }
}