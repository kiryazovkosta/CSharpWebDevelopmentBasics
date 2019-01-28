// 	<copyright file=Launcher.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/16/2019 11:24:17 AM</date>
// 	<summary>Class representing a Launcher entity</summary>
namespace SIS.ConsoleClient
{
    using Controllers;
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;


    public class Launcher
    {
        static void Main(string[] args)
        {
            var serverRounRoutingTable = new ServerRoutingTable();
            serverRounRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();
            var server = new Server(8000, serverRounRoutingTable);
            server.Run();
        }
    }
}