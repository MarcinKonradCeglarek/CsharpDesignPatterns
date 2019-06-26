namespace CSharpDesignPatterns._3._SOLID_principles
{
    using System;
    using System.IO;
    using System.Text;

    using Moq;

    using NUnit.Framework;

    internal class DependencyInversion
    {
        public string GetAndFormatData(IFileX file)
        {
            var lines = file.ReadAllLines("3. SOLID principles\\data.txt");

            var resutl = new StringBuilder();
            foreach (var line in lines)
            {
                resutl.AppendLine(line);
            }

            return resutl.ToString();
        }
    }

    [TestFixture]
    public class DependencyInversionTests
    {
        [Test]
        public void GetAndFormatData()
        {
            // Arrange
            var x = new Mock<IFileX>();
            x.Setup(o => o.ReadAllLines(It.IsAny<string>())).Returns(new[] { "ABC" });
            
            var sut = new DependencyInversion();

            // Act
            var result = sut.GetAndFormatData(x.Object);

            // Assert
            Assert.AreEqual("ABC" + Environment.NewLine, result);
        }
    }

    public interface IFileX
    {
        string[] ReadAllLines(string filename);
    }

    public class FileX : IFileX
    {
        public string[] ReadAllLines(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}