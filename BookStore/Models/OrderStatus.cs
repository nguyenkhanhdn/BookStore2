using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        
        [Display(Name = "Ngày xử lý đơn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ProcessedDate { get; set; }

        [Required(ErrorMessage = "Tình trạng đơn hàng không được để trống.")]
        [Display(Name = "Tình trạng đơn hàng")]
        public int StatusId { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Số hóa đơn không được để trống.")]
        [Display(Name = "Số hóa đơn")]
        public int OrderId { get; set; }
        public virtual Status Status { get; set; }
        public virtual Order Order { get; set; }
    }
}