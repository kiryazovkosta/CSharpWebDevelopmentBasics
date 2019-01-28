// 	<copyright file=User.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/24/2019 2:29:13 PM</date>
// 	<summary>Class representing a User entity</summary>
namespace SIS.CakesWebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class User : BaseModel<int>
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfregistration { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Order> Orders { get; set; }
    }
}