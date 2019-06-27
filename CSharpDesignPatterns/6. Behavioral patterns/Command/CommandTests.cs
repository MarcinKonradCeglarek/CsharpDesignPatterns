namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void TurnOnCommandProperlyInvokesPowerOn()
        {
            var device = new Mock<IDevice>();

            ICommand turnOff = new TurnOffDeviceCommand(device.Object);
            ICommand turnOn  = new TurnOnDeviceCommand(device.Object);

            var @switch = new PowerSwitch(turnOn, turnOff);

            @switch.TurnOn();

            device.Verify(d => d.PowerOn(),  Times.Once);
            device.Verify(d => d.PowerOff(), Times.Never);
        }

        [Ignore("")]
        [Test]
        public void TurnOffCommandProperlyInvokesPowerOff()
        {
            var device = new Mock<IDevice>();

            ICommand turnOff = new TurnOffDeviceCommand(device.Object);
            ICommand turnOn  = new TurnOnDeviceCommand(device.Object);

            var @switch = new PowerSwitch(turnOn, turnOff);

            @switch.TurnOff();

            device.Verify(d => d.PowerOn(),  Times.Never);
            device.Verify(d => d.PowerOff(), Times.Once);
        }

        [Ignore("")]
        [Test]
        public void TurnOnAndOffCommandProperlyInvokesPowerOnAndPowerOff()
        {
            var device = new Mock<IDevice>();

            ICommand turnOff = new TurnOffDeviceCommand(device.Object);
            ICommand turnOn  = new TurnOnDeviceCommand(device.Object);

            var @switch = new PowerSwitch(turnOn, turnOff);

            @switch.TurnOn();

            device.Verify(d => d.PowerOn(),  Times.Once);
            device.Verify(d => d.PowerOff(), Times.Never);

            @switch.TurnOff();

            device.Verify(d => d.PowerOn(),  Times.Once);
            device.Verify(d => d.PowerOff(), Times.Once);
        }


    }
}