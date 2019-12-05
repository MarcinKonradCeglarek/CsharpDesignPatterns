namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    public class PowerSwitch
    {
        private readonly ICommand turnOnCommand;
        private readonly ICommand turnOffCommand;

        public PowerSwitch(ICommand turnOnCommand, ICommand turnOffCommand)
        {
            this.turnOnCommand  = turnOnCommand;
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
}