namespace CSharpDesignPatterns._3._SOLID_principles._5.DependencyInversion
{
    using System;
    using System.IO;

    using NUnit.Framework;

    internal class DependencyInversion
    {
        public void GetAndFormatData()
        {
            var lines = File.ReadAllLines("3. SOLID principles\\5.DependencyInversion\\data.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }

    [TestFixture]
    public class DependencyInversionTests
    {
        [Test]
        public void GetAndFormatData()
        {
            // Arrange
            var sut = new DependencyInversion();

            // Act
            sut.GetAndFormatData();

            // Assert
            Assert.IsTrue(true);
        }
    }
}