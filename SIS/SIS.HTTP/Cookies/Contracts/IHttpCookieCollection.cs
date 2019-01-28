// 	<copyright file=IHttpCookieCollection.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/22/2019 11:49:28 AM</date>
// 	<summary>Definition of a IHttpCookieCollection interface</summary>
namespace SIS.HTTP.Cookies.Contracts
{
    using System;
    public interface IHttpCookieCollection
    {
        void Add(HttpCookie httpCookie);
        HttpCookie GetCookie(string key);
        bool ContainsCookie(string key);
        bool HasCookie();
    }
}
