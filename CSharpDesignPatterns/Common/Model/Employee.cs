namespace CSharpDesignPatterns.Common.Model
{
    internal class Employee
    {
        public Employee(Company company, Person person, string title, double salary)
        {
            this.Company = company;
            this.Person  = person;
            this.Title   = title;
            this.Salary  = salary;
        }

        public Company Company { get; }

        public Person Person { get; }

        public double Salary { get; set; }

        public string Title { get; }

        public override string ToString()
        {
            return $"{this.Person}, {this.Title} at {this.Company}";
        }

        public void UpdateGender(string newGender)
        {
            this.Person.UpdateGender(newGender);
        }
    }
}