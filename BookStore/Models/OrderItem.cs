using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StationeryId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public virtual Stationery Stationery { get; set; }
        public virtual Order Order { get; set; }
    }
}