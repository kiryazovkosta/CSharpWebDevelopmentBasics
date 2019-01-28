using SIS.WebServer;
using SIS.WebServer.Routing;
using System;

namespace CakesWebApp
{
    using Controllers;
    using SIS.HTTP.Enums;

    class Program
    {
        static void Main(string[] args)
        {
            var serverRounRoutingTable = new ServerRoutingTable();
            serverRounRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index(request);
            var server = new Server(8000, serverRounRoutingTable);
            server.Run();
        }
    }
}
