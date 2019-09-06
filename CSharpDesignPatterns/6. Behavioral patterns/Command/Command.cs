namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    using System;

    /*
     * https://en.wikipedia.org/wiki/Command_pattern
     */

    public interface ICommand
    {
        void Execute();
    }

    public class PowerSwitch
    {
        private readonly ICommand turnOffCommand;
        private readonly ICommand turnOnCommand;

        public PowerSwitch(ICommand turnOnCommand, ICommand turnOffCommand)
        {
            this.turnOnCommand = turnOnCommand;
            this.turnOffCommand = turnOffCommand;
        }

        public void TurnOff()
        {
            this.turnOffCommand.Execute();
        }

        public void TurnOn()
        {
            this.turnOnCommand.Execute();
        }
    }

    public interface IDevice
    {
        void PowerOff();
        void PowerOn();
    }

    public class TurnOffDeviceCommand : ICommand
    {
        private readonly IDevice device;

        public TurnOffDeviceCommand(IDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.PowerOff();
        }
    }

    public class TurnOnDeviceCommand : ICommand
    {
        private readonly IDevice device;

        public TurnOnDeviceCommand(IDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.PowerOn();
        }
    }
}