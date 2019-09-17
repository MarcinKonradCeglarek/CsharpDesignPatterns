namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class HashSetGenericTemplateMethodTests
    {
        private static readonly Fixture Fixture = new Fixture();

        [Test]
        public void AddsNumberToEmptyHashSet()
        {
            var value = Fixture.Create<int>();
            var hashSet = new HashSet<int>();
            var sut = new HashSetGenericTemplateMethod();

            sut.AddToParent(hashSet, value);

            Assert.AreEqual(1, hashSet.Count);
            Assert.IsTrue(hashSet.Contains(value));
        }

        [Test]
        public void AddingNumberToEmptyHashSetTwiceThrows()
        {
            var value   = Fixture.Create<int>();
            var hashSet = new HashSet<int>();
            var sut     = new HashSetGenericTemplateMethod();

            sut.AddToParent(hashSet, value);
            Assert.Throws<InvalidOperationException>(() => sut.AddToParent(hashSet, value));
        }

        [Test]
        public void RemovingNumberFromEmptyHashSetThrows()
        {
            var value   = Fixture.Create<int>();
            var hashSet = new HashSet<int>();
            var sut     = new HashSetGenericTemplateMethod();

            Assert.Throws<InvalidOperationException>(() => sut.RemoveFromParent(hashSet, value));
        }

        [Test]
        public void AddingAndRemovingNumberFromHashSet()
        {
            var value   = Fixture.Create<int>();
            var hashSet = new HashSet<int>();
            var sut     = new HashSetGenericTemplateMethod();

            sut.AddToParent(hashSet, value);
            sut.RemoveFromParent(hashSet, value);

            Assert.AreEqual(0, hashSet.Count);
        }

        [Test]
        public void MovingIntFromHashSetToHashSetWhereItAlreadyExistsThrows()
        {
            var value   = Fixture.Create<int>();
            var hashSet1 = new HashSet<int>();
            var hashSet2 = new HashSet<int>();
            var sut     = new HashSetGenericTemplateMethod();

            sut.AddToParent(hashSet1, value);
            sut.AddToParent(hashSet2, value);

            Assert.Throws<InvalidOperationException>(() => sut.MoveChild(hashSet1, hashSet2, value));
        }

        [Test]
        public void AddingMovingAndRemovingIntFromOneHashSetToAnother()
        {
            var value = 16;
            var hashSet1 = new HashSet<int>();
            var hashSet2 = new HashSet<int>();
            var sut     = new HashSetGenericTemplateMethod();

            sut.AddToParent(hashSet1, 2);
            sut.AddToParent(hashSet1, 4);
            sut.AddToParent(hashSet1, 8);

            sut.AddToParent(hashSet2, 4);
            sut.AddToParent(hashSet2, 8);
            sut.AddToParent(hashSet2, 12);

            sut.AddToParent(hashSet1, value);
            sut.MoveChild(hashSet1, hashSet2, value);
            sut.RemoveFromParent(hashSet2, value);

            Assert.IsFalse(hashSet1.Contains(value));
            Assert.IsFalse(hashSet2.Contains(value));
        }
    }
}