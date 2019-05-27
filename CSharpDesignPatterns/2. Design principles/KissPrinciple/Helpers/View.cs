namespace CSharpDesignPatterns._2._Design_principles.KissPrinciple.Helpers
{
    using System;
    using System.Collections.Generic;

    internal class View
    {
        private static Dictionary<Type, Func<object, string>> formatters = new Dictionary<Type, Func<object, string>>()
                                                                           {
                                                                               {
                                                                                   typeof(char[]), o =>
                                                                                   {
                                                                                       var input = (char[])o;
                                                                                       return new string(input);
                                                                                   }
                                                                               },
                                                                               {
                                                                                   typeof(string), o => (string)o
                                                                               }
                                                                           };
        public static string Display(object input)
        {
            if (formatters.ContainsKey(input.GetType()))
            {
                return formatters[input.GetType()](input);
            }

            throw new NotSupportedException($"Type {input.GetType()} is not supported");
        }
    }
}