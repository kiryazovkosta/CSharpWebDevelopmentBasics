// 	<copyright file=StringExtensions.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/3/2019 3:45:26 PM</date>
// 	<summary>Class representing a StringExtensions entity</summary>
namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalizes the text (makes the first letter – capital and all other – lowercase).
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Capitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (text.Length == 1)
            {
                return text.ToUpper();
            }

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }
    }
}