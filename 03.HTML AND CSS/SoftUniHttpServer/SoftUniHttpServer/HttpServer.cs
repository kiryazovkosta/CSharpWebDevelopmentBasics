// 	<copyright file=HttpServer.cs company="">
//		Copyright (c) 2018 All Rights Reserved
// 	</copyright>
// 	<author></author>
// 	<date>9/25/2018 3:21:07 PM</date>
// 	<summary>Class representing a HttpServer entity</summary>
namespace SoftUniHttpServer
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;


    public class HttpServer : IHttpServer
    {
        private bool isWorking;

        private readonly TcpListener tcpListener;

        public HttpServer()
        {
            this.isWorking = false;
            this.tcpListener = new TcpListener(IPAddress.Loopback, 8765);
        }

        public void Start()
        {
            this.tcpListener.Start();
            Console.WriteLine("Started");
            this.isWorking = true;
            while (this.isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                Task.Run(() =>  ProcessClient(client));
            }
        }

        private static async void ProcessClient(TcpClient client)
        {
            var buffer = new byte[10240];
            var stream = client.GetStream();
            Console.WriteLine($@"{client.Client.RemoteEndPoint} {Thread.CurrentThread.ManagedThreadId}");
            var readLength = await stream.ReadAsync(buffer, 0, buffer.Length);
            var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(requestText);
            await Task.Run(() => Thread.Sleep(10000));
            var responseText = File.ReadAllText("Responses/Index.html");
            //var responseText = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var responseBytes = Encoding.UTF8.GetBytes(
                "HTTP/1.0 200 OK" + Environment.NewLine +
                //"Content-Disposition: attachmant; filename=Index.exe" + Environment.NewLine +
                //"Content-Type: application/executable" + Environment.NewLine +
                //"Content-Length: " + responseText.Length +
                Environment.NewLine + Environment.NewLine +
                responseText);
            await stream.WriteAsync(responseBytes);
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}