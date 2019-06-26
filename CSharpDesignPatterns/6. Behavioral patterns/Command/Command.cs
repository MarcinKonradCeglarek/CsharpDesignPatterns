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

    public class Switch
    {
        private readonly ICommand turnOffCommand;
        private readonly ICommand turnOnCommand;

        public Switch(ICommand turnOnCommand, ICommand turnOffCommand)
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
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TurnOnSwitchCommand : ICommand
    {
        private readonly ISwitchable switchable;

        public TurnOnSwitchCommand(ISwitchable switchable)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}