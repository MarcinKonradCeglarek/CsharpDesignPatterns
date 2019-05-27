namespace CSharpDesignPatterns.Common.Model
{
    using System;

    public class Person
    {
        public Person(string name, string lastName, string gender, DateTime birthDate)
            : this(Guid.NewGuid(), name, lastName, gender, birthDate)
        {
        }

        public Person(Guid id, string name, string lastName, string gender, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public int Age => (int)((double)(DateTime.Now - this.BirthDate).Days / 365);

        public DateTime BirthDate { get; }

        public Guid Id { get; }

        public string LastName { get; }

        public string Name { get; }

        public string Gender { get; private set; }

        public void UpdateGender(string newGender)
        {
            this.Gender = newGender;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.LastName}, age {this.Age}";
        }
    }
}