using System;
using System.IO;
using System.Net;

namespace HttpClientSample
{
    class HtmlSaver
    {
        public HtmlSaver(WebPage page)
        {
            Save(page);
        }

        public void Save(WebPage page)
        {
            var webclient = new WebClient();
            int i = 0;
            foreach (var pg in page.Links)
            {
                var path = pg.Path + "/page" + i.ToString() + ".html";
                Directory.CreateDirectory(pg.Path);

                try
                {
                    webclient.DownloadFile(pg.Link, path);
                }
                catch (Exception)
                {
                }

                i++;
                Save(pg);
            }
        }
    }
}
