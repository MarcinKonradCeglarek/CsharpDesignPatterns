namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class VisitorTests
    {
        private readonly List<IComponent> components = new List<IComponent>
            {
                new Home(),
                new Park(),
                new City(3.5),
                new City(3.0),
                new Park(),
                new Home()
            };

        [Test]
        public void CitiesVisitorVisits2Cities()
        {
            var citiesVisitor = new CitiesVisitor();
            Client.ClientCode(this.components, citiesVisitor);

            Assert.AreEqual(3.25, citiesVisitor.GetAverage());
        }
    }
}
