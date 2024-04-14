using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class PDFsController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        // GET: PDFs
        public ActionResult Index()
        {
            return View(db.PDFs.ToList());
        }

        // GET: PDFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFs.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // GET: PDFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Publisher,Area,FileUrl,UploadedDate,Description")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                db.PDFs.Add(pDF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pDF);
        }

        // GET: PDFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFs.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // POST: PDFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Publisher,Area,FileUrl,UploadedDate,Description")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pDF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pDF);
        }

        // GET: PDFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFs.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // POST: PDFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PDF pDF = db.PDFs.Find(id);
            db.PDFs.Remove(pDF);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
