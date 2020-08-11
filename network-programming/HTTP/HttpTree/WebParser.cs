using CsQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace HttpClientSample
{
    public class WebParser
    {
        private string _homePage = String.Empty;
        private string _html = String.Empty;

        public WebPage WebPg { get; private set; }

        public bool ParseFinished = false;

        public WebParser(string mainLink)
        {
            var splitedLink = mainLink.Split('/');
            _homePage = splitedLink[2];
            WebPg = new WebPage(mainLink, 0);
            AsyncGetHtml(WebPg.Link);
        }
        public WebParser(WebPage webPage)
        {
            WebPg = webPage;
            var splitedLink = webPage.Link.Split('/');
            _homePage = splitedLink[2];

            AsyncGetHtml(WebPg.Link);
        }

        private async void AsyncGetHtml(string mainLink)
        {
            try
            {
                var splitedLink = mainLink.Split('/');
                if (_homePage == splitedLink[2])
                {
                    using (var client = new HttpClient())
                    using (var strStream = new StreamReader(await client.GetStreamAsync(mainLink)))
                    {
                        WebPage.OpenedLnks.Add(mainLink);
                        string newLine = String.Empty;

                        while ((newLine = strStream.ReadLine()) != null)
                        {
                            _html += newLine + "\n";
                        }

                        Parse(mainLink);
                        _html = String.Empty;
                    }
                }
            }
            catch
            {
            }
        }

        private void Parse(string mainLink)
        {
            CQ cq = CQ.Create(_html);
            foreach (IDomObject obj in cq.Find("a"))
            {
                var atr = obj.GetAttribute("href");

                if (!String.IsNullOrEmpty(atr) &&
                    !atr.StartsWith('#') &&
                    !(atr.StartsWith("tel")) &&
                    atr != mainLink)
                {
                    string atribute = AttributeRepair(atr);
                    var protocol = "https://";

                    if (WebPage.OpenedLnks.All(l => !l.Contains(atribute)) &&
                       protocol + _homePage != atribute)
                    {
                       var splittedAtribute =  atribute.Split('/');

                        if (splittedAtribute.Length <= 4 || atribute.StartsWith(protocol+_homePage))
                        {
                            WebPage webPage = new WebPage(atribute, WebPg.Depth + 1);
                            WebPg.Links.Add(webPage);

                            WebParser webParser = new WebParser(webPage);
                        }
                    }
                }
            }
        }

        private string AttributeRepair(string atr)
        {
            if (atr[0] == '/')
            {
                return "https://" + _homePage + atr;
            }

            return atr;
        }
    }
}
