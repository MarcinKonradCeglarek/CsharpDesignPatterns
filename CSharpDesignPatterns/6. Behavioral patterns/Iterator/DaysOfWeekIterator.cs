namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /*
     * https://refactoring.guru/design-patterns/iterator
     */
    public class DaysOfWeekIterator : IEnumerable<DayOfWeek>
    {
        public IEnumerator<DayOfWeek> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}