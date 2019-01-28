// 	<copyright file=AccountController.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/25/2019 12:08:28 PM</date>
// 	<summary>Class representing a AccountController entity</summary>
namespace SIS.CakesWebApp.Controllers
{
    using System;
    using System.Linq;
    using Data;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using Models;
    using Services;
    using Services.Contracts;
    using WebServer.Results;

    public class AccountController : BaseController
    {
        private readonly IHashService hashService;

        public AccountController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (string.IsNullOrEmpty(userName)
            || userName.Length < 4)
            {
                return this.BadRequestError("Please provide valid username with length minimum 4 simbols");
            }

            if (db.Users.Any(x => x.UserName == userName))
            {
                return this.BadRequestError("User with the same username already exsists");
            }

            if (string.IsNullOrEmpty(password)
                || password.Length < 6)
            {
                return this.BadRequestError("Please provide valid password with length minimum 6 simbols");
            }

            if (string.IsNullOrEmpty(confirmPassword)
                || confirmPassword.Length < 6)
            {
                return this.BadRequestError("Please provide valid confirm password with length minimum 6 simbols");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Passwords does not match!");
            }

            var hashedPassword = this.hashService.Hash(password);

            var user = new User()
            {
                Name = userName,
                Password = hashedPassword,
                UserName = userName
            };

            this.db.Users.Add(user);
            try
            {
                this.db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            return new RedirectResult("/");
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            //1. Validate input
            var userName = request.FormData["username"]?.ToString().Trim() ?? string.Empty;
            var password = request.FormData["password"]?.ToString().Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(userName)
            || string.IsNullOrWhiteSpace(password))
            {
                return this.BadRequestError("Please enter username and password!");
            }

            var hashedPasssword = this.hashService.Hash(password);
            var user = this.db.Users.FirstOrDefault(x =>
                x.UserName == userName && x.Password == hashedPasssword);
            if (user == null)
            {
                return this.BadRequestError("Invalid username or password!");
            }

            var userContent = this.cookieService.GetUserCookie(user.UserName);
            var response = new RedirectResult("/");
            response.AddCookie(new HttpCookie(".auth-cakes", userContent, 7) { HttpOnly = true });
            return response;
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            var response = new RedirectResult("/");
            if (request.Cookies.ContainsCookie(".auth-cakes"))
            {
                var cookie = request.Cookies.GetCookie(".auth-cakes");
                cookie.Delete();
                response.Cookies.Add(cookie);
            }

            return response;
        }
    }
}