namespace CSharpDesignPatterns._6._Behavioral_patterns.Command
{
    using System;

    public interface ICommand
    {
        void Execute();
    }

    public class Switch
    {
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