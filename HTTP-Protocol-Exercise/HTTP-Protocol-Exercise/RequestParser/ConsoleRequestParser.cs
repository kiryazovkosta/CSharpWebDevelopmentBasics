namespace RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Contracts;

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
            var validActions = ReadValidActions();
            IFakeHttpServer server = new FakeHttpServer(validActions);
            var request = Console.ReadLine();
            var response = server.ProcessRequest(request);
            Console.WriteLine(response);
        }

        private static IDictionary<string, HashSet<string>> ReadValidActions()
        {
            var validActions = new Dictionary<string, HashSet<string>>();
            var stopReadingActions = false;
            do
            {
                var action = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(action))
                {
                    continue;
                }

                if (action.Equals("END"))
                {
                    stopReadingActions = true;
                }
                else
                {
                    var actionParts = action.Split("/", StringSplitOptions.RemoveEmptyEntries);
                    var path = "/" + actionParts[0];
                    var method = actionParts[1].ToUpper();

                    if (!validActions.ContainsKey(path))
                    {
                        validActions[path] = new HashSet<string>();
                    }

                    if (!validActions[path].Contains(method))
                    {
                        validActions[path].Add(method);
                    }
                }
            } while (stopReadingActions != true);

            return validActions;
        }
    }
}
