using System;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            WebParser link = new WebParser("https://rozetka.com.ua");
            Console.WriteLine("Saving");
            HtmlSaver saver = new HtmlSaver(link.WebPg);
            Console.WriteLine("Saved");
        }
    }
}
