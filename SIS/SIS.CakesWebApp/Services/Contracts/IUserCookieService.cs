// 	<copyright file=IUserCookieService.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/25/2019 2:48:59 PM</date>
// 	<summary>Definition of a IUserCookieService interface</summary>
namespace SIS.CakesWebApp.Services.Contracts
{
    using System;
    public interface IUserCookieService
    {
        string GetUserCookie(string userName);
        string GetUserData(string cookieContent);
    }
}
