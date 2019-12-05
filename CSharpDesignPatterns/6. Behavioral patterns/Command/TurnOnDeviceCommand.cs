namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
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