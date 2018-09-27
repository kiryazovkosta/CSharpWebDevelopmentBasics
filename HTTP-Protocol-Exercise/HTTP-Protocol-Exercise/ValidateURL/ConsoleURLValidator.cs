namespace ValidateURL
{
    using System;

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
            string url = "http://mysite.com:80/demo/index.aspx";

            var parts = url.Split("://", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid URL");
            }

            Console.WriteLine($"Protocol: {parts[0]}");
        }
    }
}
