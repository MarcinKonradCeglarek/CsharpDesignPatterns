﻿namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void FirstDayIsMonday()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual(DayOfWeek.Monday, sut.First());
        }

        [TestCase(0, DayOfWeek.Monday)]
        [TestCase(1, DayOfWeek.Tuesday)]
        [TestCase(2, DayOfWeek.Wednesday)]
        [TestCase(3, DayOfWeek.Thursday)]
        [TestCase(4, DayOfWeek.Friday)]
        [TestCase(5, DayOfWeek.Saturday)]
        public void IsNthDayValid(int skipCount, DayOfWeek expected)
        {
            Assert.AreEqual(expected, new DaysOfWeekIterator().Skip(skipCount).First());
        }

        [Test]
        public void LastDayIsSunday()
        {
            var sut = new DaysOfWeekIterator();
            Assert.AreEqual(DayOfWeek.Sunday, sut.Last());
        }

        [Test]
        public void ThereIs7DaysInWeek()
        {
            var result = new List<DayOfWeek>();
            foreach (var dayOfWeek in new DaysOfWeekIterator())
            {
                result.Add(dayOfWeek);
            }

            Assert.AreEqual(7, result.Count);
        }

        [TestCase(0,  0)]
        [TestCase(1,  1)]
        [TestCase(2,  1)]
        [TestCase(3,  2)]
        [TestCase(4,  3)]
        [TestCase(5,  5)]
        [TestCase(6,  8)]
        [TestCase(20, 6765)]
        public void IsFibonacciNthElementValid(int skipCount, int result)
        {
            Assert.AreEqual(result, new FibonacciIterator().Skip(skipCount).First());
        }
    }
}