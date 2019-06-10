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
            var person = Factory.GetPerson(PersonType.Rural);

            Assert.IsInstanceOf<IPerson>(person);
            Assert.IsInstanceOf<Villager>(person);
            Assert.AreEqual("Farmer", person.Occupation);
        }

        [Test]
        public void FactoryMethod_UrbanPerson_IsClerk()
        {
            var person = Factory.GetPerson(PersonType.Urban);

            Assert.IsInstanceOf<IPerson>(person);
            Assert.IsInstanceOf<CityPerson>(person);
            Assert.AreEqual("Clerk", person.Occupation);
        }

        [Test]
        public void FactoryMethod_None_ThrowsException()
        {
            Assert.Throws<NotSupportedException>(() => Factory.GetPerson(PersonType.None));
        }
    }
}