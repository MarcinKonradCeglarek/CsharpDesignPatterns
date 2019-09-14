namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System.Collections;
    using System.Collections.Generic;

    /*
     * https://refactoring.guru/design-patterns/iterator
     */
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