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
        public async Task AccessFromMultipleTasksReturnsSingleInstance()
        {
            var tasks      = Enumerable.Range(0, 5).AsParallel().Select(t => Task.Run(() => SingletonViaLocking.GetInstance()));
            var singletons = await Task.WhenAll(tasks);

            var firstId = singletons[0].Id;
            Assert.IsTrue(singletons.All(s => s.Id == firstId));
        }

        [Test]
        [Repeat(25)]
        public void GetInstanceTwiceSameId()
        {
            var instance1 = SingletonViaLocking.GetInstance();
            var instance2 = SingletonViaLocking.GetInstance();

            Assert.AreEqual(instance1.Id, instance2.Id);
        }
    }
}