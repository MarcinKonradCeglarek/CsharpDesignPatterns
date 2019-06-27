namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    public static class Helper
    {
        public static bool DoesLevelMatchMask(LogLevel severity, LogLevel mask)
        {
            return (int)(severity & mask) != 0;
        }
    }
}