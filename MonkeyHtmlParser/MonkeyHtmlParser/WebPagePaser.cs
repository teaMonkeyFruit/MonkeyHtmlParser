using System.Collections.Generic;
using HtmlAgilityPack;

namespace MonkeyHtmlParser
{
    public class WebPageParser
    {
        private readonly HtmlDocument _htmlDocument;
        private readonly string _url;

        public WebPageParser(string url)
        {
            _url = url;
            var web = new HtmlWeb();
            _htmlDocument = web.Load(url);
        }

        /// <summary>
        /// Returns a set of WebNodes that contain text matching the search phrase.
        /// </summary>
        /// <param name="searchPhrase"></param>
        /// <returns></returns>
        public IEnumerable<WebNode> GetNodes(string searchPhrase)
        {
            var nodes = _htmlDocument.DocumentNode.SelectNodes($"//text()[contains(., '{searchPhrase}')]/..");

            var webNodes = new List<WebNode>();

            if (nodes == null)
                return webNodes;

            foreach (var htmlNode in nodes)
            {
                var webNode = new WebNode
                {
                    SearchPhrase = searchPhrase,
                    Url = _url,
                    Name = htmlNode.Name,
                    Text = htmlNode.InnerText
                };
                
                webNodes.Add(webNode);
            }

            return webNodes;
        }
    }
}