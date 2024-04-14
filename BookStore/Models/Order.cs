using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        [Display(Name = "Người mua hàng")]
        [Required(ErrorMessage = "Người mua hàng không được để trống.")]
        public string Name { get; set; }
        [Display(Name = "Ngày đặt mua")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> OrderedDate { get; set; }
        [Display(Name = "Phương thức giao hàng")]
        public string DeliveryType { get; set; }
        [Display(Name = "Địa chỉ nhận hàng")]
        public string Address { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

    }
}