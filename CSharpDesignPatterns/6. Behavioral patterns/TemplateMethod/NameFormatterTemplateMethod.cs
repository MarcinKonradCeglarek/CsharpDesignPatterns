namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;
    using System.Linq;

    /*
     * https://refactoring.guru/design-patterns/template-method
     *
     * NameFormatterTemplateMethod provides template and abstract methods
     *
     * PeasantNameFormatter and RoyaltyNameFormatter provides implementation for abstract methods
     */
    public abstract class NameFormatterTemplateMethod
    {
        public string GetName()
        {
            var parts = new List<string>() { this.GetPrefix() };
            parts.AddRange(this.GetFirstNames());
            parts.Add(this.GetLastName());

            return string.Join(" ", parts.Where(s => !string.IsNullOrEmpty(s)));
        }

        protected abstract IEnumerable<string> GetFirstNames();

        protected abstract string GetLastName();

        protected abstract string GetPrefix();
    }
}