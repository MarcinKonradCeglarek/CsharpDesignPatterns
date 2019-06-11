namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class ProxyTests
    {
        [Test]
        public void ProxyCar_CanDriveCar()
        {
            var driver = new Driver(33);
            var sut    = new ProxyCar(driver);

            var result = sut.DriveCar();

            Assert.AreEqual("Car has been driven!", result);
        }

        [Test]
        public void ProxyCar_CantDriveCar()
        {
            var driver = new Driver(12);
            var sut    = new ProxyCar(driver);

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }
    }
}