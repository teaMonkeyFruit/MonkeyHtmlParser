using System.Linq;
using FluentAssertions;
using Xunit;

namespace MonkeyHtmlParser.UnitTests
{
    public class Basic
    {
        private string _url = "http://www.cnn.com";
        
        [Fact]
        public void WebPageLoads()
        {
            var webPageParser = new WebPageParser(_url);

            webPageParser.Should().NotBeNull();
        }
        
        [Fact]
        public void NodesAreReturned()
        {
            var webPageParser = new WebPageParser(_url);

            var nodes = webPageParser.GetNodes("cnn");

            nodes.Should().NotBeEmpty();
        }
        
        [Fact]
        public void NodesPropertiesAreAssigned()
        {
            var webPageParser = new WebPageParser(_url);
            var searchPhrase = "cnn";

            var nodes = webPageParser.GetNodes(searchPhrase);
            var node = nodes.First();

            node.SearchPhrase.Should().Be(searchPhrase);
            node.Url.Should().Be(_url);
        }
        
        [Fact]
        public void NoNodes()
        {
            var webPageParser = new WebPageParser(_url);
            var searchPhrase = "frisjdnviuejksmfnhks";

            var nodes = webPageParser.GetNodes(searchPhrase);

            nodes.Should().BeEmpty();
        }
    }
}