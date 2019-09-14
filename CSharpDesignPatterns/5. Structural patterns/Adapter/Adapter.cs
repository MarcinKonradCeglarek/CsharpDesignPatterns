namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    /*
     * https://refactoring.guru/design-patterns/adapter
     */
    public interface IOurOldLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    public class OurOldLoggerToILoggerAdapter : IOurOldLogger
    {
        public OurOldLoggerToILoggerAdapter(ILogger newLogger)
        {
            throw new NotImplementedException();
        }

        public bool SendLogMessage(LogLevel level, string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Exception
    }
}