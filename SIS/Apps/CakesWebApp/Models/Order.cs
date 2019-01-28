// 	<copyright file=Order.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/23/2019 4:17:38 PM</date>
// 	<summary>Class representing a Order entity</summary>
namespace CakesWebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.Products = new HashSet<OrderProduct>();
        }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public virtual ICollection<OrderProduct> Products { get; set; }
    }
}