// 	<copyright file=OrderProduct.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/24/2019 10:51:41 AM</date>
// 	<summary>Class representing a OrderProduct entity</summary>
namespace CakesWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class OrderProduct : BaseModel<int>
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}