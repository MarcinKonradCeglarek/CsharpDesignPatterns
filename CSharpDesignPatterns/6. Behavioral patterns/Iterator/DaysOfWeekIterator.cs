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
            yield return DayOfWeek.Monday;
            yield return DayOfWeek.Tuesday;
            yield return DayOfWeek.Wednesday;
            yield return DayOfWeek.Thursday;
            yield return DayOfWeek.Friday;
            yield return DayOfWeek.Saturday;
            yield return DayOfWeek.Sunday;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}