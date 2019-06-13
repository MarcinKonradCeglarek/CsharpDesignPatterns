namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void TurnOffCommandProperlyInvokesPowerOff()
        {
            var device = new Mock<ISwitchable>();

            ICommand turnOff = new TurnOffSwitchCommand(device.Object);
            ICommand turnOn  = new TurnOnSwitchCommand(device.Object);

            var @switch = new Switch(turnOn, turnOff);

            @switch.TurnOff();

            device.Verify(d => d.PowerOn(),  Times.Never);
            device.Verify(d => d.PowerOff(), Times.Once);
        }

        [Test]
        public void TurnOnAndOffCommandProperlyInvokesPowerOnAndPowerOff()
        {
            var device = new Mock<ISwitchable>();

            ICommand turnOff = new TurnOffSwitchCommand(device.Object);
            ICommand turnOn  = new TurnOnSwitchCommand(device.Object);

            var @switch = new Switch(turnOn, turnOff);

            @switch.TurnOn();

            device.Verify(d => d.PowerOn(),  Times.Once);
            device.Verify(d => d.PowerOff(), Times.Never);

            @switch.TurnOff();

            device.Verify(d => d.PowerOn(),  Times.Once);
            device.Verify(d => d.PowerOff(), Times.Once);
        }

        [Test]
        public void TurnOnCommandProperlyInvokesPowerOn()
        {
            var device = new Mock<ISwitchable>();

            ICommand turnOff = new TurnOffSwitchCommand(device.Object);
            ICommand turnOn  = new TurnOnSwitchCommand(device.Object);

            var @switch = new Switch(turnOn, turnOff);

            @switch.TurnOn();

            device.Verify(d => d.PowerOn(),  Times.Once);
            device.Verify(d => d.PowerOff(), Times.Never);
        }
    }
}