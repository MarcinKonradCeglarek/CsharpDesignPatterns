namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    internal class CompanyGenericTemplateMethod : GenericTemplateMethod<Company, Employee>
    {
        protected override void AddChild(Company parent, Employee child)
        {
            throw new NotImplementedException();
        }

        protected override bool IsChild(Company parent, Employee child)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveChild(Company parent, Employee child)
        {
            throw new NotImplementedException();
        }
    }
}