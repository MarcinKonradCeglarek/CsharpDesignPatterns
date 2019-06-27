namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using NUnit.Framework;

    [TestFixture]
    public class MementoTests
    {
        private const string OriginalName = "ActionHero";

        [Test]
        public void CreateMementoAndRestore()
        {
            var original = new FacebookUser(OriginalName, new[] { "John Wick", "Thomas Anderson" });

            var firstMemento = original.CreateMemento();
            CareTaker caretaker = new CareTaker { Memento = firstMemento };

            original.Name = "Little Pony";
            original.Friends.Add("Barbie");

            Assert.AreEqual("Little Pony", original.Name);
            Assert.AreEqual(3,            original.Friends.Count);

            // Retrieve back first State
            original.Restore(caretaker.Memento);

            Assert.AreEqual(OriginalName, original.Name);
            Assert.AreEqual(2, original.Friends.Count);
        }
    }
}
