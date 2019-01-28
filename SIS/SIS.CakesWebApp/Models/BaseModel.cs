// 	<copyright file=BaseModel.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/24/2019 2:25:26 PM</date>
// 	<summary>Class representing a BaseModel entity</summary>
namespace SIS.CakesWebApp.Models
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}