namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    internal class CompanyGenericTemplateMethod : GenericTemplateMethod<Company, Employee>
    {
        protected override void AddChild(Company parent, Employee child)
        {
            parent.Hire(child.Person, child.Title, child.Salary);
        }

        protected override bool IsChild(Company parent, Employee child)
        {
            return parent.Employees.ContainsKey(child.Id);
        }

        protected override void RemoveChild(Company parent, Employee child)
        {
            parent.Sack(child.Id);
        }
    }
}