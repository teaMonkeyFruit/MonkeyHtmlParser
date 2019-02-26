using FluentAssertions;
using Xunit;

namespace MonkeyHtmlParser.UnitTests
{
    public class Basic
    {
        private string _url = "http://www.dolekemp96.org/main.htm";
        
        [Fact]
        public void WebPageLoads()
        {
            var webPageParser = new WebPageParser(_url);

            webPageParser.Should().NotBeNull();
        }
    }
}