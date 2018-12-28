// 	<copyright file=HttpServer.cs company="">
//		Copyright (c) 2018 All Rights Reserved
// 	</copyright>
// 	<author></author>
// 	<date>9/27/2018 7:28:40 PM</date>
// 	<summary>Class representing a HttpServer entity</summary>
namespace RequestParser
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class FakeHttpServer : IFakeHttpServer
    {
        private readonly IDictionary<string, HashSet<string>> actions;

        public FakeHttpServer(IDictionary<string, HashSet<string>> actionsParam)
        {
            this.actions = actionsParam;
        }

        public string ProcessRequest(string request)
        {
            // POST /login HTTP/1.1
            var requestParts = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (requestParts.Length != 3)
            {
                throw new ArgumentException(nameof(request));
            }

            var method = requestParts[0].ToUpper();
            var action = requestParts[1];
            var version = requestParts[2].ToUpper();

            var code =
                this.actions.ContainsKey(action) && this.actions[action].Contains(method)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.NotFound;

            return CreateResponse(version, code);
        }

        private string CreateResponse(string version, HttpStatusCode code)
        {
            var response = new StringBuilder();
            response.AppendLine($"{version} {(int)code} {code}");
            response.AppendLine($"Content-Length: {code.ToString().Length}");
            response.AppendLine($"Content-Type: text/plain" + Environment.NewLine);
            response.AppendLine($"{code}");

            return response.ToString().Trim();
        }
    } 
}