// 	<copyright file=InternalServerErrorException.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/3/2019 11:07:07 AM</date>
// 	<summary>Class representing a InternalServerErrorException entity</summary>
namespace SIS.HTTP.Exceptions
{
    using System;
    using Enums;

    public class InternalServerErrorException : Exception
    {
        private const string InternalServerErrorExceptionMessage = "The Server has encountered an error.";

        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.InternalServerError; 
        public InternalServerErrorException()
            : base(InternalServerErrorExceptionMessage)
        {
        }

        public InternalServerErrorException(string message)
            : base(message)
        {
        }
    }
}