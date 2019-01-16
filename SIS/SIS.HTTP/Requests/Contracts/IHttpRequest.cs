// 	<copyright file=IHttpRequest.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/4/2019 11:52:12 AM</date>
// 	<summary>Definition of a IHttpRequest interface</summary>
namespace SIS.HTTP.Requests.Contracts
{
    using System.Collections.Generic;
    using Enums;
    using Headers.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }
        HttpRequestMethod RequestMethod { get; }
    }
}
