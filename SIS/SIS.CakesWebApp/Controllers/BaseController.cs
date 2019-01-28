// 	<copyright file=BaseController.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/25/2019 11:40:15 AM</date>
// 	<summary>Class representing a BaseController entity</summary>
namespace SIS.CakesWebApp.Controllers
{
    using System.IO;
    using Data;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using Services;
    using Services.Contracts;
    using WebServer.Results;

    public class BaseController
    {
        protected readonly IUserCookieService cookieService;
        protected CakesDbContext db { get; }

        public BaseController()
        {
            this.db = new CakesDbContext();
            this.cookieService = new UserCookieService();
        }

        protected string GetUsername(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return null;
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            var cookieContent = cookie.Value;
            var userName = this.cookieService.GetUserData(cookieContent);
            return userName;
        }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText("Views/" + viewName + ".html");
            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.InternalServerError);
        }
    }
}