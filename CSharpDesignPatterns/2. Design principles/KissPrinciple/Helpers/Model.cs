namespace CSharpDesignPatterns._2._Design_principles.KissPrinciple.Helpers
{
    using System;

    using Newtonsoft.Json;

    internal class Model
    {
        public BasicModel<char[]> Message => new BasicModel<char[]>("[ 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x57, 0x6f, 0x72, 0x6c, 0x64 ]");

        internal class BasicModel<T>
        {
            public BasicModel(string content)
            {
                this.Content = content;
            }

            public string Content { get; }

            public T GetObject()
            {
                return JsonConvert.DeserializeObject<T>(this.Content);
            }
        }
    }
}