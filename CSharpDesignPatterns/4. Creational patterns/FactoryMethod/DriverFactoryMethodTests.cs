namespace CSharpDesignPatterns._4._Creational_patterns.FactoryMethod
{
    using System;

    using CSharpDesignPatterns._4._Creational_patterns.FactoryMethod.Model;

    using NUnit.Framework;

    [TestFixture]
    public class DriverFactoryMethodTests
    {
        [Test]
        public void GetDriverForGrapicsReturnsGraphicsDriver()
        {
            var driver = DriverFactoryMethod.GetDriver(DriverType.Graphics);

            Assert.IsInstanceOf<GraphicsCardDriver>(driver);
            Assert.AreEqual(new GraphicsCardDriver().DeviceType, driver.DeviceType);
        }

        [Test]
        public void GetDriverForUsbReturnsUsbDriver()
        {
            var driver = DriverFactoryMethod.GetDriver(DriverType.Usb);

            Assert.IsInstanceOf<UsbDriver>(driver);
            Assert.AreEqual(new UsbDriver().DeviceType, driver.DeviceType);
        }

        [Test]
        public void GetDriverForHardDiskReturnsHardDiskDriver()
        {
            var driver = DriverFactoryMethod.GetDriver(DriverType.HardDisk);

            Assert.IsInstanceOf<HardDiskDriver>(driver);
            Assert.AreEqual(new HardDiskDriver().DeviceType, driver.DeviceType);
        }

        [Test]
        public void GetDriverForInvalidDriverTypeThrows()
        {
            Assert.Throws<NotSupportedException>(() => DriverFactoryMethod.GetDriver(DriverType.None));
        }

        [Test]
        public void GetDriverForNotExisingDriverTypeThrows()
        {
            Assert.Throws<NotSupportedException>(() => DriverFactoryMethod.GetDriver((DriverType)15));
        }
    }
}