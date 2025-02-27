﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S1120342HW4.Models;

namespace S1120342HW4.Controllers
{
    public class iPhonesController : Controller
    {
        private TourSurveyEntities db = new TourSurveyEntities();

        // GET: iPhones
        public ActionResult Index()
        {
            return View(db.iPhone.ToList());
        }

        // GET: iPhones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iPhone iPhone = db.iPhone.Find(id);
            if (iPhone == null)
            {
                return HttpNotFound();
            }
            return View(iPhone);
        }

        // GET: iPhones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: iPhones/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,type,price,wafer,weight,battery")] iPhone iPhone)
        {
            if (ModelState.IsValid)
            {
                db.iPhone.Add(iPhone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iPhone);
        }

        // GET: iPhones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iPhone iPhone = db.iPhone.Find(id);
            if (iPhone == null)
            {
                return HttpNotFound();
            }
            return View(iPhone);
        }

        // POST: iPhones/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,type,price,wafer,weight,battery")] iPhone iPhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iPhone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iPhone);
        }

        // GET: iPhones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iPhone iPhone = db.iPhone.Find(id);
            if (iPhone == null)
            {
                return HttpNotFound();
            }
            return View(iPhone);
        }

        // POST: iPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            iPhone iPhone = db.iPhone.Find(id);
            db.iPhone.Remove(iPhone);
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
