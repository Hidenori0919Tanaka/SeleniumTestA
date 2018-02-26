using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitTest_Sample.Entity.RDB;
using UnitTest_Sample.Models;

namespace UnitTest_Sample.Controllers
{
    public class SecsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Secs
        public ActionResult Index()
        {
            var secs = db.Secs.Include(s => s.Fa);
            return View(secs.ToList());
        }

        // GET: Secs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sec sec = db.Secs.Find(id);
            if (sec == null)
            {
                return HttpNotFound();
            }
            return View(sec);
        }

        // GET: Secs/Create
        public ActionResult Create()
        {
            ViewBag.FaId = new SelectList(db.Fas, "FaId", "FaName");
            return View();
        }

        // POST: Secs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SecId,FaId,CreateDate,UpdateDate,DeleteFlag")] Sec sec)
        {
            if (ModelState.IsValid)
            {
                db.Secs.Add(sec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FaId = new SelectList(db.Fas, "FaId", "FaName", sec.FaId);
            return View(sec);
        }

        // GET: Secs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sec sec = db.Secs.Find(id);
            if (sec == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaId = new SelectList(db.Fas, "FaId", "FaName", sec.FaId);
            return View(sec);
        }

        // POST: Secs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SecId,FaId,CreateDate,UpdateDate,DeleteFlag")] Sec sec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FaId = new SelectList(db.Fas, "FaId", "FaName", sec.FaId);
            return View(sec);
        }

        // GET: Secs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sec sec = db.Secs.Find(id);
            if (sec == null)
            {
                return HttpNotFound();
            }
            return View(sec);
        }

        // POST: Secs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sec sec = db.Secs.Find(id);
            db.Secs.Remove(sec);
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
