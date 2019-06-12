namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    using System;

    public interface ICommand
    {
        void Execute();
    }

    public class Switch
    {
        private readonly ICommand turnOnCommand;
        private readonly ICommand turnOffCommand;

        public Switch(ICommand turnOnCommand, ICommand turnOffCommand)
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

    public interface ISwitchable
    {
        void PowerOff();
        void PowerOn();
    }

    public class TurnOffSwitchCommand : ICommand
    {
        private readonly ISwitchable switchable;

        public TurnOffSwitchCommand(ISwitchable switchable)
        {
            this.switchable = switchable;
        }

        public void Execute()
        {
            this.switchable.PowerOff();
        }
    }

    public class TurnOnSwitchCommand : ICommand
    {
        private readonly ISwitchable switchable;

        public TurnOnSwitchCommand(ISwitchable switchable)
        {
            this.switchable = switchable;
        }

        public void Execute()
        {
            this.switchable.PowerOn();
        }
    }
}