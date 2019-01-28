// 	<copyright file=HashService.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/25/2019 12:57:10 PM</date>
// 	<summary>Class representing a HashService entity</summary>
namespace SIS.CakesWebApp.Services
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Contracts;

    public class HashService : IHashService
    {
        public string Hash(string stringToHash)
        {
            stringToHash = stringToHash + "myAppSalt1234984647624274649847246#";
            using (var sha256 = SHA1.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "".ToLower());
                return hash;
            }
        }
    }
}