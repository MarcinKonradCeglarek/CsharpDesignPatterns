namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System.Collections;
    using System.Collections.Generic;

    public class DaysOfWeekIterator : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Monday";
            yield return "Tuesday";
            yield return "Wednesday";
            yield return "Thorsday";
            yield return "Freeday";
            yield return "Saturnday";
            yield return "Sunday";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}