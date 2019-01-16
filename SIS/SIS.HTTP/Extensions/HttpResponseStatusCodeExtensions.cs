// 	<copyright file=HttpResponseStatusCodeExtensions.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/4/2019 10:47:32 AM</date>
// 	<summary>Class representing a HttpResponseStatusCodeExtensions entity</summary>
namespace SIS.HTTP.Extensions
{
    using Enums;

    public static class HttpResponseStatusCodeExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode code)
            => $"{(int)code} {code}";
    }
}