﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext():base("name=DefaultConnection")
        {        
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Stationery> Stationeries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PDF> PDFs { get; set; }
    }
}