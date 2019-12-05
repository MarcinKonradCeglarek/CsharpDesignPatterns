﻿namespace CSharpDesignPatterns._3._SOLID_principles
{
    using System.IO;
    using System.Text;

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
}