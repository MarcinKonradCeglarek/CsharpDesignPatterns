namespace CSharpDesignPatterns._3._SOLID_principles._1.SingleResponsibility
{
    using System.Net;

    using CSharpDesignPatterns.Common.Model;

    using NUnit.Framework;

    internal class SingleResponsibility
    {
        /*
         * "A class should have only one reason to change,"
         *
         * This class can change because:
         * - data for document would change
         * - formatting of report would change
         * - printer would change
         *
         */
        internal void ProduceReport()
        {
            var data = this.GetReportData();
            var reportDocument = this.FormatReport(data);

            var printer = this.GetPrinter(IPAddress.None);
            this.PrintReport(printer, reportDocument);
        }

        internal Document FormatReport(string data)
        {
            return new Document(data);
        }

        internal string GetReportData()
        {
            return "Report";
        }

        internal void PrintReport(Printer printer, Document reportDocument)
        {
            printer.Print(reportDocument);
        }

        internal Printer GetPrinter(IPAddress address)
        {
            return new Printer(address);
        }
    }

    [TestFixture]
    internal class SingleResponsibilityTests
    {
        [Test]
        public void ProduceReport()
        {
            // Arrange
            var sut = new SingleResponsibility();

            // Act
            sut.ProduceReport();
        }

        [Test]
        public void GetPrinter()
        {
            var sut = new SingleResponsibility();

            // Act
            var printer = sut.GetPrinter(IPAddress.Parse("192.168.0.1"));

            // Assert
            Assert.IsInstanceOf<Printer>(printer);
            Assert.IsNotNull(printer.Address);
            Assert.AreEqual(IPAddress.Parse("192.168.0.1"), printer.Address);
        }
    }
}