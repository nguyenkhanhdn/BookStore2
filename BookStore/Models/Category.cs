using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Loại dụng cụ học tập không được rỗng.")]
        [Display(Name = "Loại dụng cụ")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Không được để trống mô tả.")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Không được để trống ảnh đại diện.")]
        [Display(Name = "Ảnh đại diện")]
        public string Img { get; set; }

        public virtual ICollection<Stationery> Stationeries { get; set; }
    }
}