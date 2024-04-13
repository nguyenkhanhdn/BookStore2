using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        [Display(Name = "Học sinh")]
        [Required(ErrorMessage = "Học sinh không được để trống.")]
        public int StudentId { get; set; }
        [Display(Name = "Sách")]
        [Required(ErrorMessage = "Sách không được để trống.")]
        public string BookCode { get; set; }
        [Display(Name = "Ngày mượn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> RegDate { get; set; }
        [Display(Name = "Hình thức nhận sách")]
        public string RecMethod { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

    }
}