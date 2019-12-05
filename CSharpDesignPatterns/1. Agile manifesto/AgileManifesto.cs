namespace CSharpDesignPatterns._1._Agile_manifesto
{
    using System.Security.Policy;

    internal class AgileManifesto
    {
        /*
         * 11-13.02.2001 Snowbird, Utah
         *
         * Individuals and interactions     over processes and tools
         * Working software                 over comprehensive documentation
         * Customer collaboration           over contract negotiation
         * Responding to change             over following a plan
         */
        public static Url ManifestoUrl { get; } = new Url("https://agilemanifesto.org");

        public static Url WikiPage { get; } = new Url("https://pl.wikipedia.org/wiki/Manifest_Agile");
    }
}