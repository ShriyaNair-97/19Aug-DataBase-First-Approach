using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductDatabaseApproach;

namespace ProductDatabaseApproach.Controllers
{
    public class Product_tblController : Controller
    {
        private ProductEntities db = new ProductEntities();

        // GET: Product_tbl
        public ActionResult Index()
        {
            var product_tbl = db.Product_tbl.Include(p => p.ProductDetail);
            return View(product_tbl.ToList());
        }

        // GET: Product_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_tbl product_tbl = db.Product_tbl.Find(id);
            if (product_tbl == null)
            {
                return HttpNotFound();
            }
            return View(product_tbl);
        }

        // GET: Product_tbl/Create
        public ActionResult Create()
        {
            ViewBag.Model_id = new SelectList(db.ProductDetails, "Model_id", "Model_name");
            return View();
        }

        // POST: Product_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_id,Product_name,Rate,Model_id")] Product_tbl product_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Product_tbl.Add(product_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Model_id = new SelectList(db.ProductDetails, "Model_id", "Model_name", product_tbl.Model_id);
            return View(product_tbl);
        }

        // GET: Product_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_tbl product_tbl = db.Product_tbl.Find(id);
            if (product_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Model_id = new SelectList(db.ProductDetails, "Model_id", "Model_name", product_tbl.Model_id);
            return View(product_tbl);
        }

        // POST: Product_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_id,Product_name,Rate,Model_id")] Product_tbl product_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Model_id = new SelectList(db.ProductDetails, "Model_id", "Model_name", product_tbl.Model_id);
            return View(product_tbl);
        }

        // GET: Product_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_tbl product_tbl = db.Product_tbl.Find(id);
            if (product_tbl == null)
            {
                return HttpNotFound();
            }
            return View(product_tbl);
        }

        // POST: Product_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_tbl product_tbl = db.Product_tbl.Find(id);
            db.Product_tbl.Remove(product_tbl);
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
