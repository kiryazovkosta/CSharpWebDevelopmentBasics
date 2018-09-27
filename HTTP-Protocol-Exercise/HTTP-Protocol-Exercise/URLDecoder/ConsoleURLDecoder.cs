namespace URLDecoder
{
    using System;
    using System.Net;

    /// <summary>
    /// You have been tasked to write a simple Console URL Decoder. You will receive an encoded URL. 
    /// Your job is to decode the URL and print its decoded version on the console.
    /// </summary>
    public class ConsoleURLDecoder
    {
        public static void Main()
        {
            Console.WriteLine(DecodeUrl("http://www.google.bg/search?q=C%23"));
            Console.WriteLine(DecodeUrl("https://mysite.com/show?n%40m3= p3%24h0"));
            Console.WriteLine(DecodeUrl("http://url-decoder.com/i%23de%25?id=23"));
            Console.WriteLine(DecodeUrl(string.Empty));
            Console.WriteLine(DecodeUrl(null));
        }

        public static string DecodeUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(nameof(url));
            }

            return WebUtility.UrlDecode(url);
        }
    }
}