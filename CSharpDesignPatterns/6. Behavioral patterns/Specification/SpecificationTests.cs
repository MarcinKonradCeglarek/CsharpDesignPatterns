namespace CSharpDesignPatterns._6._Behavioral_patterns.Specification
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class SpecificationTests
    {
        [Test]
        public void OrAnd_ProperlyWorksForGivenConditions()
        {
            var greaterThan0 = new IntGreaterThan(0);
            var lessThan10 = new IntLessThan(10);

            var over9000 = new IntGreaterThan(9000);
        
            var myCondition = over9000.Or(greaterThan0.And(lessThan10));

            Assert.IsTrue(myCondition.IsSatisfiedBy(5));
            Assert.IsTrue(myCondition.IsSatisfiedBy(9999));
        }

        [Test]
        public void Alternative()
        {
            Func<int, bool> myCondition = a => a > 9000 || (a > 0 && a < 10);

            Assert.IsTrue(myCondition(5));
            Assert.IsTrue(myCondition(9999));
        }
    }
}
