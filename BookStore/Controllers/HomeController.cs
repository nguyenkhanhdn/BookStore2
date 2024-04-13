using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Data;

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

        public ActionResult AddToCart(int id, int quantity = 1)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.AddItem(id.ToString(), quantity, 300);
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
        [HttpGet]
        [Authorize]
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
        public ActionResult PlaceOrder(string StudentId, string RegDate, string RecMethod, string address, string Phone, string note)
        {
            Member regInfo = null;

            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null) //Nếu trong giỏ chưa có cuốn sách nào -> về trang chủ
            {
                cart = new ShoppingCart();
                RedirectToAction("Index");
            }
            else
            {
                foreach (DataRow row in cart.CartItems.Rows)
                {
                    regInfo = new Member();
                    regInfo.BookCode = Guid.NewGuid().ToString();//""GetBookCodeFromBookId(int.Parse(row[0].ToString()));
                    regInfo.StudentId = int.Parse(StudentId);
                    regInfo.RegDate = DateTime.Parse(RegDate);
                    regInfo.RecMethod = RecMethod;
                    regInfo.Address = address;
                    regInfo.Phone = Phone;
                    regInfo.Note = note;
                    db.Members.Add(regInfo);
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