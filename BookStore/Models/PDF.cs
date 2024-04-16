using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class PDF
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Lớp")]
        [Required(ErrorMessage = "Lớp yêu cầu phải nhập")]
        public int ClassId { get; set; }

        [Display(Name = "Tựa sách")]
        [Required(ErrorMessage = "Yêu cầu phải nhập")]
        public string Title { get; set; }
        [Display(Name = "Nhà xuất bản")]
        
        public string Publisher { get; set; }
        [Display(Name = "Sách dùng cho trường/quận")]
        [Required(ErrorMessage = "Yêu cầu phải nhập")]
        public string Area { get; set; }
        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "Yêu cầu phải nhập")]
        public string FileUrl { get; set; }
        [Display(Name = "Ngày tải")]
        [Required(ErrorMessage = "Yêu cầu phải nhập")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UploadedDate { get; set; }
        [Display(Name = "Thông tin mô tả")]

        public string Description { get; set; }
    }
}