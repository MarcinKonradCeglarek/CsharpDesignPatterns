namespace CSharpDesignPatterns._3._SOLID_principles
{
    using System;
    using System.IO;
    using System.Text;

    using NUnit.Framework;

    internal class DependencyInversion
    {
        /* We could use System.IO.Abstractions here to inject IFile to better test this */
        public string GetAndFormatData()
        {
            var lines = File.ReadAllLines("3. SOLID principles\\data.txt");

            var result = new StringBuilder();
            foreach (var line in lines)
            {
                result.AppendLine(line);
            }

            return result.ToString();
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
            var result = sut.GetAndFormatData();

            // Assert
            Assert.AreEqual("ABC" + Environment.NewLine, result);
        }
    }

    /*public interface IFile
    {
        string[] ReadAllLines(string filename);
    }

    public class FileX : IFile
    {
        public string[] ReadAllLines(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }*/
}