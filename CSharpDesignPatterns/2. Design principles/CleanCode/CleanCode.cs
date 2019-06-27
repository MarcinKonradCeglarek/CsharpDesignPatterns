namespace CSharpDesignPatterns._2._Design_principles.CleanCode
{
    using System.Security.Policy;

    internal class CleanCode
    {
        private static Url OReillyUrl { get; } = new Url("https://www.oreilly.com/library/view/clean-code/9780136083238/");

        private static string[] UsefulTools { get; } = { "Resharper.StyleCop", "ESLint" };

        public static int AlwaysUseBraces(int i)
        {
            for (var j = 0; j < 100; j++);
                i++;

            // What will be return value?
            return i;
        }

        public static void IfYouHaveToUseCommentsYoureDoingSomethingWrong(object probably)
        {
        }
    }
}