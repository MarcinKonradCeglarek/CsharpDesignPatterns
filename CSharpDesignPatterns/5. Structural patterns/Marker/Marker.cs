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

    public abstract class Plant
    {
    }

    public class Tree : Plant
    {
    }

    public class Mushroom : Plant
    {
    }

    public class Bush : Plant
    {
    }

    public abstract class Animal
    {
    }

    public class Dog : Animal
    {
    }

    public class Elephant : Animal
    {
    }

    public class Human : Animal
    {
    }
}