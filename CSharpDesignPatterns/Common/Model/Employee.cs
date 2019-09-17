namespace CSharpDesignPatterns.Common.Model
{
    using System;

    internal class Employee
    {
        public Employee(Person person, string title, double salary)
        {
            this.Person  = person;
            this.Title   = title;
            this.Salary  = salary;
        }

        public Guid    Id      => this.Person.Id;
        public Person  Person  { get; }
        public double  Salary  { get; set; }
        public string  Title   { get; }

        public override string ToString()
        {
            return $"{this.Person}, {this.Title}";
        }

        public void UpdateGender(string newGender)
        {
            this.Person.UpdateGender(newGender);
        }
    }
}