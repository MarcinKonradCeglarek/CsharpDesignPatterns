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
            throw new NotImplementedException();
        }

        public int NumberOfBedrooms()
        {
            throw new NotImplementedException();
        }
    }

    public class Park : IComponent
    {
        private Guid id = Guid.NewGuid();

        public string Name => $"Park {id}";

        public void Accept(IPlacesVisitor placesVisitor)
        {
            throw new NotImplementedException();
        }
    }

    public class City : IComponent
    {
        public City(double airQuality)
        {
            throw new NotImplementedException();
        }

        public double AirQualityIndex { get; }

        public void Accept(IPlacesVisitor placesVisitor)
        {
            throw new NotImplementedException();
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
        public void Visit(Home home)
        {
            throw new NotImplementedException();
        }

        public void Visit(Park park)
        {
            throw new NotImplementedException();
        }

        public void Visit(City city)
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumber()
        {
            throw new NotImplementedException();
        }
    }

    public class CitiesVisitor : IPlacesVisitor
    {
        public void Visit(Home home)
        {
            throw new NotImplementedException();
        }

        public void Visit(Park park)
        {
            throw new NotImplementedException();
        }

        public void Visit(City city)
        {
            throw new NotImplementedException();
        }

        public double GetAverage()
        {
            throw new NotImplementedException();
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
