// 	<copyright file=BadRequestException.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/3/2019 10:07:25 AM</date>
// 	<summary>Class representing a BadRequestException entity</summary>
namespace SIS.HTTP.Exceptions
{
    using System;
    using Enums;

    public class BadRequestException : Exception
    {

        private static string BadRequestExceptionDefaultMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.BadRequest;

        public BadRequestException()
            : base(BadRequestExceptionDefaultMessage)
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}