namespace CSharpDesignPatterns.Common.Model
{
    using System;

    public interface ILogger
    {
        void LogDebug(string        message);
        void LogError(string        message);
        void LogException(Exception ex, string message);
        void LogInfo(string         message);
        void LogWarn(string         message);
    }
}