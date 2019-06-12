namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class CacheTemplateMethod
    {
        public string GetResource(string url)
        {
            if (!this.CheckCache(url, out var content))
            {
                content = this.FetchResource(url);
                this.UpdateCache(url, content);
            }

            return content;
        }

        protected abstract bool CheckCache(string url, out string content);

        protected abstract string FetchResource(string url);

        protected abstract void UpdateCache(string url, string content);
    }

    public class InMemCache : CacheTemplateMethod
    {
        private readonly Dictionary<string, string> cache = new Dictionary<string, string>();

        public InMemCache(IRemoteDataFetcher remoteDataFetcher)
        {
            this.RemoteDataFetcher = remoteDataFetcher;
        }

        private IRemoteDataFetcher RemoteDataFetcher { get; }

        protected override bool CheckCache(string url, out string content)
        {
            if (this.cache.ContainsKey(url))
            {
                content = this.cache[url];
                return true;
            }

            content = string.Empty;
            return false;
        }

        protected override string FetchResource(string url)
        {
            return this.RemoteDataFetcher.FetchUrl(url);
        }

        protected override void UpdateCache(string url, string content)
        {
            this.cache[url] = content;
        }
    }

    public interface IRemoteDataFetcher
    {
        string FetchUrl(string url);
    }
}