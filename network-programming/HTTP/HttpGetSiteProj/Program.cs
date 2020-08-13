using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            WebParser link = new WebParser("https://rozetka.com.ua");
            Console.WriteLine("Building the tree");

           // Console.ReadKey(true);

            Save(link.WebPg);
        }

        public static void Save(WebPage webPage)
        {
            int i = 0;
            foreach (var page in webPage.Links)
            {
                var path = page.Path + "/page" + i.ToString() + ".html";
                Directory.CreateDirectory(page.Path);


                File.WriteAllText(path, page.Html);

                Save(page);
                i++;
            }
        }
    }
}
