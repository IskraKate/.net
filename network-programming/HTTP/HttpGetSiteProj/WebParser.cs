using CsQuery;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HttpClientSample
{
    public class WebParser
    {
        static int counter;
        private string _homePage = String.Empty;
        private string _html = String.Empty;

        public WebPage WebPg { get; private set; }

        public bool ParseFinished = false;

        public WebParser(string mainLink)
        {
            var splitedLink = mainLink.Split('/');

            if (splitedLink.Length >= 2)
                _homePage = splitedLink[2];


            WebPg = new WebPage(mainLink, _homePage);

            WebPage.OpenedLnks.Add(mainLink);
            GetHtml(WebPg.Link);
        }

        public WebParser(WebPage webPage)
        {
            WebPg = webPage;
            var splitedLink = webPage.Link.Split('/');

            if(splitedLink.Length>=2)
                _homePage = splitedLink[2];


            WebPage.OpenedLnks.Add(webPage.Link);
            GetHtml(WebPg.Link);
        }

        private void GetHtml(string mainLink)
        {
            if (counter > 3)
                return;

            string urlAddress = mainLink;

            if(urlAddress.StartsWith("https://") || urlAddress.StartsWith("https://"))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;

                        if (String.IsNullOrWhiteSpace(response.CharacterSet))
                            readStream = new StreamReader(receiveStream);
                        else
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                        _html = readStream.ReadToEnd();
                         WebPg.Html = _html;

                        counter++;

                        response.Close();
                        readStream.Close();

                        Parse(mainLink);
                    }
                }
                catch
                { }
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

                    if (WebPage.OpenedLnks.All(l => l != atribute && l + '/' != atribute) &&
                       protocol + _homePage != atribute && atribute != "https://m.rozetka.com.ua/")
                        {
                        var splittedAtribute = atribute.Split('/');

                        if (splittedAtribute.Length <= 4 || atribute.StartsWith(protocol + _homePage))
                        {
                            if(atr.StartsWith("https://") || atr.StartsWith("http://"))
                            atr = atr.Remove(0, 8);

                            for (int i = 0; i < atr.Length;)
                            {
                                if (!char.IsLetterOrDigit(atr[i]) && atr[i] != '.')
                                {
                                    atr = atr.Replace(atr[i], '.');
                                }
                                else
                                    i++;
                            }

                            WebPg.Html = _html;
                            WebPg.Links.Add(new WebPage(atribute,_homePage +'/'+ atr));
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