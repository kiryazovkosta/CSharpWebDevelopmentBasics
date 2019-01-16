// 	<copyright file=HomeController.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/16/2019 11:21:55 AM</date>
// 	<summary>Class representing a HomeController entity</summary>
namespace SIS.ConsoleClient.Controllers
{
    using HTTP.Enums;
    using HTTP.Responses.Contracts;
    using WebServer.Results;


    public class HomeController
    {

        public IHttpResponse Index()
        {
            var content = "<h1>Hello, world!</h1>";
            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}