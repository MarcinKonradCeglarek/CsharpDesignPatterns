namespace CSharpDesignPatterns._4._Creational_patterns.Builder.Model
{
    using System;

    [Flags]
    public enum EngineType
    {
        Diesel   = 1,
        Gasoline = 2,
        Electric = 4,
        Hybrid   = 6
    }
}