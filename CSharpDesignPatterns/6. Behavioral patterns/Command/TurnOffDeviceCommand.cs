namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    using System;

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
}