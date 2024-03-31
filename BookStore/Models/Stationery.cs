using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Stationery
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống tên.")]
        [Display(Name="Dụng cụ học tập")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Không được để trống mô tả.")]
        [Display(Name = "Mô tả")]
        public string Brief { get; set; }
        [Required(ErrorMessage = "Không được để trống ảnh đại diện.")]
        [Display(Name = "Ảnh đại diện")]
        public string Img { get; set; }
        [Required(ErrorMessage = "Không được để trống số lượng.")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Không được để trống giá.")]
        [Display(Name = "Đơn giá")]
        public float Price { get; set; }
        [Display(Name = "Loại dụng cụ")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}