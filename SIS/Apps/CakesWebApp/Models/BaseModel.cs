// 	<copyright file=BaseModel.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/23/2019 4:12:40 PM</date>
// 	<summary>Class representing a BaseModel entity</summary>
namespace CakesWebApp.Models
{
    using System;

    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}