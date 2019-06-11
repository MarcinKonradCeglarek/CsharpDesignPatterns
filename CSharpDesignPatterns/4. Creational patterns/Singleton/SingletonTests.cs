namespace CSharpDesignPatterns._4._Creational_patterns.Singleton
{
    using System.Linq;
    using System.Threading.Tasks;

    using NUnit.Framework;

    [TestFixture]
    public class SingletonTests
    {
        [Test]
        [Repeat(25)]
        public async Task Singleton_AccessFromMultipleTasks_SameGuid()
        {
            var tasks      = Enumerable.Range(0, 5).AsParallel().Select(t => Task.Run(() => Singleton.GetInstance()));
            var singletons = await Task.WhenAll(tasks);

            var firstGuid = singletons[0].Id;
            Assert.IsTrue(singletons.All(s => s.Id == firstGuid));
        }

        [Test]
        [Repeat(25)]
        public void SingletonTests_GetInstanceTwice_SameGuid()
        {
            var instance1 = Singleton.GetInstance();
            var instance2 = Singleton.GetInstance();

            Assert.AreEqual(instance1.Id, instance2.Id);
        }
    }
}