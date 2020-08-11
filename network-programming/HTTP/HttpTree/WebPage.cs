using System.Collections.Generic;

namespace HttpClientSample
{
    public class WebPage
    {
        public static List<string> OpenedLnks { get; set; } = new List<string>();
        public string Link { get; set; } = string.Empty;
        public List<WebPage> Links { get; set; } = new List<WebPage>();
        public int Depth { get; set; } = 0;

        public WebPage(string link, int depth)
        {
            Link = link;
            Depth = depth;
        }
    }
}
