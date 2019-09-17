namespace CSharpDesignPatterns.Common.Model
{
    using System;

    [Flags]
    public enum LogLevel
    {
        Info              = 0b00000001,
        Debug             = 0b00000010,
        Warning           = 0b00000100,
        Error             = 0b00001000,
        FunctionalMessage = 0b00010000,
        FunctionalError   = 0b00100000,
        All               = 0b00111111
    }
}