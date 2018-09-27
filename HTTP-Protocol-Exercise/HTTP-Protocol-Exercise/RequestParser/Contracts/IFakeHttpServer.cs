// 	<copyright file=ISingleRequestHttpServer.cs company="">
//		Copyright (c) 2018 All Rights Reserved
// 	</copyright>
// 	<author></author>
// 	<date>9/27/2018 7:27:34 PM</date>
// 	<summary>Definition of a ISingleRequestHttpServer interface</summary>
namespace RequestParser.Contracts
{
    public interface IFakeHttpServer
    {
        string ProcessRequest(string request);
    }
}
