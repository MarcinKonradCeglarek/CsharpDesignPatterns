namespace CSharpDesignPatterns._6._Behavioral_patterns.Memento
{
    using System;
    using System.Collections.Generic;

    public class CareTaker
    {
        public CareTaker(FacebookUser user, IEnumerable<Action<FacebookUser>> actions)
        {
            var mememnto = user.CreateMemento();
            try
            {
                foreach (var action in actions)
                {
                    action(user);
                }
            }
            catch
            {
                user.Restore(mememnto);
            }
        }
    }
}