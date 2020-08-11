using System;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            WebParser link = new WebParser("https://rozetka.com.ua");
            Console.WriteLine("Building the tree");
            Console.ReadKey(true);

            Console.WriteLine(link.WebPg.Link);
            Display(link.WebPg);
        }

        public static void Display(WebPage webPage)
        {
            foreach (var page in webPage.Links)
            {
                for (int i = 0; i < page.Depth; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(page.Link);

                Display(page);
            }
        }
    }
}
