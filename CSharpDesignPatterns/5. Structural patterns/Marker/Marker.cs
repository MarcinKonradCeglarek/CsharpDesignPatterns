namespace CSharpDesignPatterns._5._Structural_patterns.Marker
{
    using System;

    public interface IAlive
    {
    }

    public interface IPlant
    {
    }

    public interface IAnimal
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
    public abstract class Plant : IAlive, IPlant
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
    public abstract class Animal : IAlive, IAnimal
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

    [Animal, Sentient]
    public class Human : Animal
    {
    }
}