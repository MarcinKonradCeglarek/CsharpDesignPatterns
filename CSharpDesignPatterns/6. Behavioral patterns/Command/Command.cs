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
        public PowerSwitch(ICommand turnOnCommand, ICommand turnOffCommand)
        {
            throw new NotImplementedException();
        }

        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public void TurnOn()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TurnOnDeviceCommand : ICommand
    {
        private readonly IDevice device;

        public TurnOnDeviceCommand(IDevice device)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}