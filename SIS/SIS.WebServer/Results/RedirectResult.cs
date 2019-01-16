// 	<copyright file=RedirectResult.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/16/2019 8:57:32 AM</date>
// 	<summary>Class representing a RedirectResult entity</summary>
namespace SIS.WebServer.Results
{
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;


    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            :base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}