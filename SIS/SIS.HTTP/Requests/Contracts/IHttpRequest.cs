// 	<copyright file=IHttpRequest.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/4/2019 11:52:12 AM</date>
// 	<summary>Definition of a IHttpRequest interface</summary>
namespace SIS.HTTP.Requests.Contracts
{
    using System.Collections.Generic;
    using Cookies.Contracts;
    using Enums;
    using Headers.Contracts;
    using Sessions.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookieCollection Cookies { get; }
        HttpRequestMethod RequestMethod { get; }
        IHttpSession Session { get; set; }
    }
}
