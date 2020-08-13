using System.Collections.Generic;

namespace HttpClientSample
{
    public class WebPage
    {
        public static List<string> OpenedLnks { get; set; } = new List<string>();
        public string Link { get; set; } = string.Empty;
        public string Html { get; set; } = string.Empty;
        public List<WebPage> Links { get; set; } = new List<WebPage>();
        public string Path { get; set; } = string.Empty;

        public WebPage(string link, string path)
        {
            Link = link;
            Path = path;
            WebParser webParser = new WebParser(this);
        }
    }
}
