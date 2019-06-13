namespace CSharpDesignPatterns._5._Structural_patterns.Marker
{
    using System;

    public interface IAlive
    {
    }

    public class PlantAttribute : Attribute
    {
    }

    public class AnimalAttribute : Attribute
    {
    }

    public class SentientAttribute : Attribute
    {
    }

    [Plant]
    public abstract class Plant : IAlive
    {
    }

    [Plant]
    public class Tree : Plant
    {
    }

    [Plant]
    public class Mushroom : Plant
    {
    }

    [Plant]
    public class Bush : Plant
    {
    }

    [Animal]
    public abstract class Animal : IAlive
    {
    }

    [Animal]
    public class Dog : Animal
    {
    }

    [Animal]
    public class Elephant : Animal
    {
    }

    [Animal]
    [Sentient]
    public class Human : Animal
    {
    }
}