namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class VisitorTests
    {
        [Test]
        public void X()
        {
            List<IComponent> components = new List<IComponent>
                {
                    new Home(),
                    new Park(),
                    new City(3.5),
                    new City(3.0),
                };

            /*var visitor1 = new CitiesVisitor();
            Client.ClientCode(components, visitor1);

            Assert., visitor1.GetAverage();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new HouseAndParksVisitor();
            Client.ClientCode(components, visitor2);*/
    }
    }
}
