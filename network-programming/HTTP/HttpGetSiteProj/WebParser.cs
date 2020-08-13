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
        private string _homePage = String.Empty;
        private string _html = String.Empty;
        private static string _url;
        private static string _mUrl;

        public WebPage WebPg { get; private set; }

        public bool ParseFinished = false;

        public WebParser(string urlAddress)
        {
            _url = urlAddress;
            if(_url.StartsWith("https"))
            {
                _mUrl = _url.Insert(8, "m.");
            }
            else
            {
                _mUrl = _url.Insert(7, "m.");
            }

            var splitedLink = urlAddress.Split('/');

            if (splitedLink.Length >= 2)
                _homePage = splitedLink[2];

            WebPg = new WebPage(urlAddress, _homePage);
            WebPage.OpenedLnks.Add(urlAddress);
            GetHtml(WebPg.Link);
        }

        public WebParser(WebPage webPage)
        {
            WebPg = webPage;
            var splitedLink = webPage.Link.Split('/');

            if(splitedLink.Length>=2)
                _homePage = splitedLink[2];

            GetHtml(WebPg.Link);
        }

        private void GetHtml(string urlAddress)
        {
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

                        response.Close();
                        readStream.Close();

                        Parse(urlAddress);
                    }
                }
                catch
                { }
            }
        }

        private void Parse(string urlAddress)
        {
            CQ cq = CQ.Create(_html);
            foreach (IDomObject obj in cq.Find("a"))
            {
                var atr = obj.GetAttribute("href");

                if (!String.IsNullOrEmpty(atr) &&
                    !atr.StartsWith('#') &&
                    !(atr.StartsWith("tel")) &&
                    atr != urlAddress)
                {
                    string atribute = AttributeRepair(atr);
                    var protocol = "https://";

                    var splittedAtribute = atribute.Split('/');

                    if (WebPage.OpenedLnks.All(l => l != atribute && l + '/' != atribute) &&
                       protocol + _homePage != atribute &&
                       atribute != _mUrl &&
                       atribute != _mUrl + '/' &&
                       atribute != _url &&
                       atribute != _url + '/' &&
                       !atribute.Contains(_url + "/ua")&&
                       splittedAtribute.Length <= 5)
                    {

                        //Console.WriteLine(atribute);

                        if (splittedAtribute.Length <= 3 || atribute.StartsWith(_url))
                        {
                            Console.WriteLine(atribute);

                            atr = ComposeDirPath(atr);

                            WebPage.OpenedLnks.Add(atribute);

                            string purified = _url.Remove(0,8);
                            WebPg.Links.Add(new WebPage(atribute, purified + '/'+ atr));
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

        private string ComposeDirPath(string atr)
        {
            if (atr.StartsWith("https://") || atr.StartsWith("http://"))
                atr = atr.Remove(0, 8);

            for (int i = 0; i < atr.Length;i++)
            {
                if (!char.IsLetterOrDigit(atr[i]) && atr[i] != '.' && atr[i] != '/')
                {
                    atr = atr.Replace(atr[i], '.');
                }
            }

            for (int i = 0; i < atr.Length;)
            {

                if (char.IsDigit(atr[i]))
                {
                    atr = atr.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }

                return atr;
        }
    }
}