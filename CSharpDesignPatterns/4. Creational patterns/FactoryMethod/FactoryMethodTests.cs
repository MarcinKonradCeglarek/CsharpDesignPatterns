namespace CSharpDesignPatterns._4._Creational_patterns.FactoryMethod
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class FactoryMethodTests
    {
        [Test]
        public void FactoryMethod_RularPerson_IsFarmer()
        {
            var person = PeopleFactory.GetPerson(PersonType.Rural);

            Assert.IsInstanceOf<IPerson>(person);
            Assert.IsInstanceOf<Villager>(person);
            Assert.AreEqual("Farmer", person.Occupation);
        }

        [Test]
        public void FactoryMethod_UrbanPerson_IsClerk()
        {
            var person = PeopleFactory.GetPerson(PersonType.Urban);

            Assert.IsInstanceOf<IPerson>(person);
            Assert.IsInstanceOf<CityPerson>(person);
            Assert.AreEqual("Clerk", person.Occupation);
        }

        [Test]
        public void FactoryMethod_None_ThrowsException()
        {
            Assert.Throws<NotSupportedException>(() => PeopleFactory.GetPerson(PersonType.None));
        }
    }
}