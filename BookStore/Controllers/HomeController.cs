using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Data;
using System.Net;
//using Microsoft.Owin;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        public ActionResult Index()
        {
            var stationeries = db.Stationeries.OrderByDescending(s => s.Id).Take(3);
            return View(stationeries.ToList());
        }
        public ActionResult StationerybyCategoryId(int catId)
        {
            var stationeries = db.Stationeries.Where(s => s.CategoryId == catId).OrderByDescending(s => s.Id);
            return View("Index", stationeries.ToList());
        }
        [Authorize]
        public ActionResult PdfViewers(int classId)
        {
            return View(db.PDFs.Where(p=>p.ClassId==classId).ToList());
        }


        public ActionResult Search()
        {
            var stationeries = db.Stationeries.Include(s => s.Category).OrderByDescending(s => s.Id);
            return View(stationeries.ToList());
          
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stationery stationery = db.Stationeries.Find(id);
            if (stationery == null)
            {
                return HttpNotFound();
            }
            return View(stationery);
        }
        [HttpPost]
        public ActionResult AddToCart(FormCollection forms)
        {
            int id = int.Parse(forms["id"]);
            int price = int.Parse(forms["price"]);
            int quantity = int.Parse(forms["quantity"]);
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.AddItem(id.ToString(), quantity, price);
            //Save cart
            Session["cart"] = cart;
            return RedirectToAction("YourCart");
        }
        public ActionResult YourCart()
        {
            //Models.NorthwindEntities db = new Models.NorthwindEntities();
            //return View(db.Categories.Include("Products").ToList());
            return View();
        }
        [Authorize]
        public ActionResult YourOrders()
        {
            string userId = User.Identity.Name;
            var orders = db.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.OrderedDate);
            return View(orders.ToList());
        }

        [HttpGet]
        
        public ActionResult PlaceOrder()
        {
            try
            {
                //var email = GetEmailFromUserName(User.Identity.Name);

                ShoppingCart cart = Session["cart"] as ShoppingCart;//Sách trong session (giỏ)
                if (cart == null)
                {
                    RedirectToAction("Index");
                }
                //var student = db.Students.Where(s => s.Email == email).FirstOrDefault();
                //ViewBag.StudentId = student.Id;
                //ViewBag.Address = student.Address;
                //ViewBag.Phone = student.Phone;
                //ViewBag.Fullname = student.Name;
            }
            catch (Exception ex)
            {

            }

            return View();
        }
        [Authorize()]//Những người đã đăng nhập
        [HttpPost]
        public ActionResult PlaceOrder(string name, DateTime orderedDate, string deliveryType, string address, string Phone, string note="Chờ xác nhận")
        {
            Order order = null;

            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null) //Nếu trong giỏ chưa có cuốn sách nào -> về trang chủ
            {
                cart = new ShoppingCart();
                RedirectToAction("Index");
            }
            else
            {
                order = new Order();
                order.Name = name;//""GetBookCodeFromBookId(int.Parse(row[0].ToString()));
                order.DeliveryType = deliveryType;
                order.OrderedDate = orderedDate;
                order.Address = address;
                order.Phone = Phone;
                order.Note = note;
                order.UserId = User.Identity.Name;
                db.Orders.Add(order);
                db.SaveChanges();
                int orderId = order.Id;

                foreach (DataRow row in cart.CartItems.Rows)
                {
                    var orderItem = new OrderItem();
                    orderItem.OrderId = orderId;
                    orderItem.StationeryId = int.Parse(row[0].ToString());
                    orderItem.Quantity = int.Parse(row[2].ToString());
                    orderItem.Price = float.Parse(row[3].ToString());
                    db.OrderItems.Add(orderItem);
                }
                db.SaveChanges();
            }

            Session["cart"] = null;
            return View("Success");
        }

        public ActionResult RemoveItem(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.RemoveItem(id.ToString());
            return RedirectToAction("YourCart");
        }
    }
}