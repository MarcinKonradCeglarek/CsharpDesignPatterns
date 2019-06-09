namespace CSharpDesignPatterns.Common.Model
{
    using System;
    using System.Net;

    internal class Device
    {
        public Device(IPAddress address)
        {
            this.Address = address;
        }

        public IPAddress Address { get; }
    }

    internal class Printer : Device
    {
        public Printer(IPAddress address)
            : base(address)
        {
        }

        internal void Print(Document document)
        {
            Console.WriteLine($"Printing {document.Title}");
        }
    }

    internal class Document
    {
        public Document(string title)
        {
            this.Title = title;
        }

        public string Title { get; }
    }
}