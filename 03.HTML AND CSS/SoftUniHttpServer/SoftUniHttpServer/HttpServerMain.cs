// 	<copyright file = HttpServer.cs company="">
//		Copyright (c) 2018 All Rights Reserved
// 	</copyright>
// 	<author></author>
// 	<date>9/25/2018 3:21:07 PM</date>
// 	<summary>Class representing a HttpServer entity</summary>
namespace SoftUniHttpServer
{
    using Contracts;

    public class HttpServerMain
    {
        public static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            server.Start();
        }
    }
}
