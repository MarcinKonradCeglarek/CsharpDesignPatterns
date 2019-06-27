namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class ProxyTests
    {
        [Test]
        public void MatureDriverWithDrivingLicenseCanDriveCar()
        {
            var driver = new Driver(33, true);
            var sut    = new ProxyCar(driver, new Car());

            var result = sut.DriveCar();

            Assert.AreEqual("Car has been driven!", result);
        }

        [Ignore("Check driving license")]
        [Test]
        public void MatureDriverWithoutDrivingLicenseCantDriveCar()
        {
            var driver = new Driver(33, false);
            var sut    = new ProxyCar(driver, new Car());

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }

        [Ignore("Check driving license")]
        [Test]
        public void UnderAgeDriverWithoutDrivingLicenseCantDriveCar()
        {
            var driver = new Driver(12, false);
            var sut    = new ProxyCar(driver, new Car());

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }

        [Ignore("Check Age")]
        [Test]
        public void UnderAgeDriverWithDrivingLicenseCantDriveCar()
        {
            var driver = new Driver(12, true);
            var sut    = new ProxyCar(driver, new Car());

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }
    }
}