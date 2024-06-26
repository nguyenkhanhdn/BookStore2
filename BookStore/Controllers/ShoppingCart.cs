﻿using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace BookStore.Controllers
{
    public class ShoppingCart
    {
        private BookStoreContext db = new BookStoreContext();

        // internal member variables
        private String user;
        private DataTable items;
        private Double total;

        // public properties
        public String UserID
        {
            get { return user; }
            set { user = value; }
        }
        public DataTable CartItems
        {
            get { return items; }
            set { items = value; }
        }
        public Double TotalValue
        {
            get { return total; }
            set { total = value; }
        }


        // default constructor
        public ShoppingCart()
        {
            // create an empty shopping cart
            user = String.Empty;
            // create an empty DataTable to hold the cart items
            items = new DataTable("Items");
            items.Columns.Add(new DataColumn("ProductID", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("ProductName", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("Quantity", Type.GetType("System.Int32")));
            items.Columns.Add(new DataColumn("Price", Type.GetType("System.Double")));
            items.Columns.Add(new DataColumn("Amount", Type.GetType("System.Double")));
            // set total value of the new cart to zero 
            total = 0;
        }
        public void UpdateCart()
        {
            //your Update cart
        }
        public string GetProductNameById(int id)
        {

            var stationery = db.Stationeries.Find(id);
            if (stationery != null)
                return stationery.Name;
            else 
                return "N/A";
        }
        public void RemoveItem(string productID)
        {
            DataRow[] rows = items.Select("ProductID='" + productID + "'");
            if (rows.Length > 0)
            {
                items.Rows.Remove(rows[0]);
            }
        }
        // add an item to the cart
        public void AddItem(String proId, Int32 Qty, Double price)
        {
            if (!IsExistItem(proId))
            {
                // create new DataTable row and populate with values - Hàng mới
                DataRow row = items.NewRow();
                row["ProductID"] = proId;
                row["ProductName"] = GetProductNameById(Convert.ToInt32(proId));
                row["Quantity"] = Qty;
                row["Price"] = price;
                row["Amount"] = Qty * price;
                // add row to DataTable update total value
                items.Rows.Add(row);
                total += (Qty * price);
            }
            else
            {
                //tăng số lượng hàng trong giỏ hàng
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    if (items.Rows[i]["ProductID"].Equals(proId))
                    {
                        int newQty = int.Parse(items.Rows[i]["Quantity"].ToString()) + Qty;
                        items.Rows[i]["Quantity"] = newQty;
                        items.Rows[i]["Amount"] = newQty * price;
                        total += (newQty * price);
                        break;//Thoat vong lap
                    }
                }
            }
        }
        public bool IsExistItem(string proID)
        {
            bool b = false;
            if (items.Rows.Count > 0)
            {
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    if (items.Rows[i]["ProductID"].Equals(proID))
                    {
                        b = true;
                        break;//Thoat vong lap
                    }
                }
            }
            return b;
        }
        // empty the cart by clearing the DataTable
        public void Clear()
        {
            items.Rows.Clear();
            total = 0;
        }
    }
}