// 	<copyright file=Product.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/23/2019 4:17:07 PM</date>
// 	<summary>Class representing a Product entity</summary>
namespace CakesWebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.Orders = new HashSet<OrderProduct>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<OrderProduct> Orders { get; set; }
    }
}