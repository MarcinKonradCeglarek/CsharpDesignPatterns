namespace CSharpDesignPatterns._6._Behavioral_patterns.Visitor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IComponent
    {
        void Accept(IPlacesVisitor placesVisitor);
    }

    public class Home : IComponent
    {
        public void Accept(IPlacesVisitor placesVisitor)
        {
            placesVisitor.Visit(this);
        }

        public int NumberOfBedrooms()
        {
            return 3;
        }
    }

    public class Park : IComponent
    {
        private Guid id = Guid.NewGuid();

        public string Name => $"Park {id}";

        public void Accept(IPlacesVisitor placesVisitor)
        {
            placesVisitor.Visit(this);
        }
    }

    public class City : IComponent
    {
        public City(double airQuality)
        {
            this.AirQualityIndex = airQuality;
        }

        public double AirQualityIndex { get; }

        public void Accept(IPlacesVisitor placesVisitor)
        {
            placesVisitor.Visit(this);
        }
    }

    public interface IPlacesVisitor
    {
        void Visit(Home home);
        void Visit(Park park);
        void Visit(City city);
    }

    public class HouseAndParksVisitor : IPlacesVisitor
    {
        private int totalBedrooms = 0;

        private List<string> parkNames = new List<string>();

        public void Visit(Home home)
        {
            this.totalBedrooms += home.NumberOfBedrooms();
        }

        public void Visit(Park park)
        {
            this.parkNames.Add(park.Name);
        }

        public void Visit(City city)
        {
        }

        public int GetTotalNumber()
        {
            return this.totalBedrooms + this.parkNames.Count;
        }
    }

    public class CitiesVisitor : IPlacesVisitor
    {
        private List<double> airQualities = new List<double>();

        public void Visit(Home home)
        {
        }

        public void Visit(Park park)
        {
        }

        public void Visit(City city)
        {
            this.airQualities.Add(city.AirQualityIndex);
        }

        public double GetAverage()
        {
            return this.airQualities.Average();
        }
    }

    public class Client
    {
        public static void ClientCode(List<IComponent> components, IPlacesVisitor placesVisitor)
        {
            foreach (var component in components)
            {
                component.Accept(placesVisitor);
            }
        }
    }
}
