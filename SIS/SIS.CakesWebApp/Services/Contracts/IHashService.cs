// 	<copyright file=IHashService.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/25/2019 12:58:41 PM</date>
// 	<summary>Definition of a IHashService interface</summary>
namespace SIS.CakesWebApp.Services.Contracts
{
    using System;

    public interface IHashService
    {
        string Hash(string stringToHash);
    }
}
