// 	<copyright file=IHttpServer.cs company="">
//		Copyright (c) 2018 All Rights Reserved
// 	</copyright>
// 	<author></author>
// 	<date>9/25/2018 3:18:49 PM</date>
// 	<summary>Definition of a IHttpServer interface</summary>
namespace SoftUniHttpServer.Contracts
{
    public interface IHttpServer
    {
        void Start();
        void Stop();
    }
}
