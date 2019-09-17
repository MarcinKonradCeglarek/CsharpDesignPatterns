namespace CSharpDesignPatterns._6._Behavioral_patterns.Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /*
     * https://refactoring.guru/design-patterns/iterator
     */
    public class FibonacciIterator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 0;
            yield return 1;

            var a = 0;
            var b = 1;

            while (true)
            {
                var sum = a + b;
                a = b;
                b = sum;
                yield return sum;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}