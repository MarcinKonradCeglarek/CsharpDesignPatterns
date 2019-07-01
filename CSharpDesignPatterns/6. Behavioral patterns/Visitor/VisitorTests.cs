namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        [Test]
        public void CitiesUsingLinq()
        {
            var average = this.components.OfType<City>().Average(c => c.AirQualityIndex);
            Assert.AreEqual(3.25, average);
        }


        [Test]
        public void HomeAndParkVisitorCounts()
        {
            var citiesVisitor = new HouseAndParksVisitor();
            Client.ClientCode(this.components, citiesVisitor);

            Assert.AreEqual(8, citiesVisitor.GetTotalNumber());
        }

        [Test]
        public void HomeAndParkUsingLinq()
        {
            Func<IComponent, int> actOnObject = c =>
                {
                    if (c is Home h)
                    {
                        return h.NumberOfBedrooms();
                    }
                    else if (c is Park)
                    {
                        return 1;
                    }

                    return 0;
                };

            var sum = this.components.Sum(c => actOnObject(c));
            Assert.AreEqual(8, sum);
        }
    }
}
