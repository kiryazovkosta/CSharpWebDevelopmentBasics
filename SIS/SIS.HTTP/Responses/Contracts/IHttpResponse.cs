// 	<copyright file=IHttpResponse.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/15/2019 1:52:05 PM</date>
// 	<summary>Definition of a IHttpResponse interface</summary>
namespace SIS.HTTP.Responses.Contracts
{
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Headers;
    using Headers.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookieCollection Cookies { get; }
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        void AddCookie(HttpCookie cookie);
        byte[] GetBytes();
    }
}