// 	<copyright file=OrderProduct.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/24/2019 2:31:41 PM</date>
// 	<summary>Class representing a OrderProduct entity</summary>
namespace SIS.CakesWebApp.Models
{
    public class OrderProduct : BaseModel<int>
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}