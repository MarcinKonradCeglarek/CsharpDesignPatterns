namespace CSharpDesignPatterns.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal class Company
    {
        private readonly IDictionary<Guid, Employee> employees = new Dictionary<Guid, Employee>();

        public Company(string name)
        {
            this.Name = name;
        }

        public IReadOnlyDictionary<Guid, Employee> Employees => new ReadOnlyDictionary<Guid, Employee>(this.employees);

        public string Name { get; }

        public void Hire(Person person, string title, double salary)
        {
            if (this.employees.ContainsKey(person.Id))
            {
                throw new ApplicationException($"Person {person} is already hired");
            }

            this.employees.Add(person.Id, new Employee(this, person, title, salary));
        }

        public void Raise(Guid id, double newSalary)
        {
            if (this.employees.ContainsKey(id))
            {
                this.employees[id].Salary = newSalary;
            }

            throw new ApplicationException($"Person {id} is not currently hired");
        }

        public void Sack(Guid id)
        {
            if (this.employees.ContainsKey(id))
            {
                this.employees.Remove(id);
            }

            throw new ApplicationException($"Person {id} is not currently hired");
        }

        public void UpdateEmployeeGender(Guid id, string newGender)
        {
            if (this.employees.ContainsKey(id))
            {
                this.employees[id].UpdateGender(newGender);
            }
        }
    }
}