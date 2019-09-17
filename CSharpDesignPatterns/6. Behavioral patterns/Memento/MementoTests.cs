namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class MementoTests
    {
        private const string NewName      = "Little Pony";
        private const string OriginalName = "ActionHero";

        [Test]
        public void CreateMementoAndCommitChanges()
        {
            var original = new FacebookUser(OriginalName, new[] { "John Wick", "Thomas Anderson" });

            var caretaker = new CareTaker(
                original,
                new Action<FacebookUser>[] { u => u.ChangeName(NewName), u => u.AddFriend("Barbie") });

            Assert.AreEqual(NewName, original.Name);
            Assert.AreEqual(3,       original.Friends.Count);
        }

        [Test]
        public void CreateMementoAndFallbackOnException()
        {
            var original = new FacebookUser(OriginalName, new[] { "John Wick", "Thomas Anderson" });

            var caretaker = new CareTaker(
                original,
                new Action<FacebookUser>[]
                    {
                        u => u.ChangeName(NewName),
                        u => u.AddFriend("Barbie"),
                        u => throw new InvalidOperationException()
                    });

            Assert.AreEqual(OriginalName, original.Name);
            Assert.AreEqual(2,            original.Friends.Count);
        }
    }
}