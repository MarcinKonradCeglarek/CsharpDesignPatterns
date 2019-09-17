namespace CSharpDesignPatterns._5._Structural_patterns.Proxy
{
    using System;

    using CSharpDesignPatterns._5._Structural_patterns.Proxy.Model;

    using NUnit.Framework;

    [TestFixture]
    public class CarProxyTests
    {
        [Test]
        public void MatureDriverWithDrivingLicenseCanDriveCar()
        {
            var driver = new Driver(33, true);
            var sut    = new CarProxy(driver, new Car());

            var result = sut.DriveCar();

            Assert.AreEqual("Car has been driven!", result);
        }

        [Test]
        public void MatureDriverWithDrivingLicenseCanDriveCarEdgeCase()
        {
            var driver = new Driver(18, true);
            var sut    = new CarProxy(driver, new Car());

            var result = sut.DriveCar();

            Assert.AreEqual("Car has been driven!", result);
        }

        [Test]
        public void MatureDriverWithoutDrivingLicenseCantDriveCar()
        {
            var driver = new Driver(33, false);
            var sut    = new CarProxy(driver, new Car());

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }

        [Test]
        public void UnderAgeDriverWithDrivingLicenseCantDriveCar()
        {
            var driver = new Driver(12, true);
            var sut    = new CarProxy(driver, new Car());

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }

        [Test]
        public void UnderAgeDriverWithoutDrivingLicenseCantDriveCar()
        {
            var driver = new Driver(12, false);
            var sut    = new CarProxy(driver, new Car());

            Assert.Throws<InvalidOperationException>(() => sut.DriveCar());
        }
    }
}