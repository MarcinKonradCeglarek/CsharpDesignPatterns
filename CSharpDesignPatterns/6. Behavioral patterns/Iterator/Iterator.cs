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

    public class FibonacciIterator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            var a = 1;
            var b = 1;

            yield return 1;
            yield return 1;

            while (true)
            {
                var c = a + b;
                a = b;
                b = c;
                yield return b;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}