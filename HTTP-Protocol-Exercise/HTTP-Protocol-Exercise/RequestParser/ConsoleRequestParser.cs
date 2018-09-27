namespace RequestParser
{
    using System;

    /// <summary>
    /// You have been tasked to write a console application that simulates an HTTP Server’s behavior. 
    /// You will be receiving HTTP requests and printing HTTP responses for them in a custom format.
    /// You will receive several lines with valid paths.The last part of the path will be the allowed method. Keep reading paths until you receive "END".
    /// 
    /// After that, you will receive a HTTP request. You will have to parse the request and return a response based on that request. 
    /// If the path of the given request CANNOT be found in the received paths or the request method is NOT allowed for the path, the result will be:
    /// •	Status: 404 Not Found
    /// •	Response Text: NotFound
    /// 
    /// In all other cases the result will be:
    /// •	Status: 200 OK
    /// •	Response Text: OK
    /// </summary>
    public class ConsoleRequestParser
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
