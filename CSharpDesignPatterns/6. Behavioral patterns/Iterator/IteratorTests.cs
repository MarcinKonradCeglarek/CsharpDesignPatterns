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
        public void ConcatenateDays()
        {
            var result = string.Empty;
            foreach (var dayOfWeek in new DaysOfWeekIterator())
            {
                result += dayOfWeek + ",";
            }
    
        }

        [Test]
        public void asdfasdf()
        {
            var sut    = new DaysOfWeekIterator();
            var tuesday = sut.Skip(1).Take(1);
        }


        [Test]
        public void ThereIs7DaysInWeek()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual(7, sut.Count());
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 5)]
        [TestCase(5, 8)]
        public void FibonacciTest1(int skipCOunt, int result)
        {
            Assert.AreEqual(result, new FibonacciIterator().Skip(skipCOunt).First());
        }
    }
}