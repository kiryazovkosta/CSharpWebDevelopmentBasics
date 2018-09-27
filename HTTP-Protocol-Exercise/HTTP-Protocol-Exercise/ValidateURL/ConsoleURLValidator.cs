namespace ValidateURL
{
    using System;
    using System.Net;
    using System.Text;

    /// <summary>
    /// You have been tasked to create a simple Console URL Validator. The validator works with custom rules though. 
    /// You will receive encoded URL.Decode the URL and validate it.
    /// •	If the URL is valid, you must break it into its composite particles and print them.
    /// •	If the URL is invalid, you must print an error.
    /// </summary>
    public class ConsoleURLValidator
    {
        public static void Main(string[] args)
        {
            // read from console or sone other input
            //http://mysite.com:80/demo/index.aspx
            //https://my-site.bg/
            //https://mysite.bg/demo/search?id=22o#go

            //https://mysite:80/demo/index.aspx
            //somesite.com:80/search?
            //https/mysite.bg?id=2

            var url = "https://softuni.bg:443/search?Query=pesho&Users=true#go";
            var decodedUrl = DecodeUrl(url);

            try
            {
                var uri = new Uri(decodedUrl);
                if (string.IsNullOrWhiteSpace(uri.Scheme)
                    || string.IsNullOrWhiteSpace(uri.Host)
                    || string.IsNullOrWhiteSpace(uri.LocalPath)
                    || uri.IsDefaultPort == false
                )
                {
                    Console.WriteLine("Invalid URL");
                }
                else
                {
                    var result = GetPartsFromUri(uri);
                    Console.WriteLine(result.ToString());
                }
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Invalid URL");
            }

        }

        private static StringBuilder GetPartsFromUri(Uri uri)
        {
            var result = new StringBuilder();
            result.AppendLine($"Protocol: {uri.Scheme}");
            result.AppendLine($"Host: {uri.Host}");
            result.AppendLine($"Port: {uri.Port}");
            result.AppendLine($"Path: {uri.LocalPath}");
            if (!string.IsNullOrWhiteSpace(uri.Query))
            {
                result.AppendLine($"Query: {uri.Query.Split("?", StringSplitOptions.RemoveEmptyEntries)[0]}");
            }

            if (!string.IsNullOrWhiteSpace(uri.Fragment))
            {
                result.AppendLine($"Fragment: {uri.Fragment}");
            }

            return result;
        }

        public static string DecodeUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            return WebUtility.UrlDecode(url);
        }
    }
}
