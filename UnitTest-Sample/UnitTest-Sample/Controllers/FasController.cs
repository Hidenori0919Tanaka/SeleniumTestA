using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitTest_Sample.Models;

namespace UnitTest_Sample.Controllers
{
    public class FasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fas
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var faList =
                    (from p in context.Fas
                     where !p.DeleteFlag
                     orderby p.CreateDate ascending
                     select p).AsNoTracking().ToList();

                return View(faList);
            }
        }

        // GET: Fas/Details/5
        public ActionResult Details(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                var fa =
                    (from p in context.Fas
                     where !p.DeleteFlag && p.FaId == id
                     && id != null
                     select p).FirstOrDefault();

                if (fa == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    return View(fa);
                }
            }
        }

        // GET: Fas/Create
        public ActionResult Create()
        {
            using (var context = new ApplicationDbContext())
            {
                var faUserList =
                    (from p in context.ApplicationUsers
                     where !p.LockoutEnabled
                     orderby p.UserName ascending
                     select p).AsNoTracking().ToList();

                if (faUserList == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    ViewBag.UserId = new SelectList(faUserList, "Id", "Email");
                    return View();
                }

                
            }
        }

        // POST: Fas/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaId,FaName,UserId,CreateDate,UpdateDate,DeleteFlag")] Fa fa)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    context.Fas.Add(fa);
                    context.SaveChanges();
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    var faUserList =
                        (from p in context.ApplicationUsers
                        where !p.LockoutEnabled
                        orderby p.UserName ascending
                        select p).AsNoTracking().ToList();
                    ViewBag.UserId = new SelectList(faUserList, "Id", "Email");
                    return View();
                }
            }
        }

        // GET: Fas/Edit/5
        public ActionResult Edit(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                var faUserList =
                    (from p in context.ApplicationUsers
                     where !p.LockoutEnabled
                     orderby p.UserName ascending
                     select p).AsNoTracking().ToList();

                var fa =
                    (from p in context.Fas
                     where id == p.FaId && !p.DeleteFlag
                     select p).FirstOrDefault();

                if (faUserList == null || fa == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    ViewBag.UserId = new SelectList(faUserList, "Id", "Email", fa.UserId);
                    return View(fa);
                }
            }
        }

        // POST: Fas/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaId,FaName,UserId,CreateDate,UpdateDate,DeleteFlag")] Fa fa)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    context.Entry(fa).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var faUserList =
                        (from p in context.ApplicationUsers
                         where !p.LockoutEnabled
                         orderby p.UserName ascending
                         select p).AsNoTracking().ToList();
                    ViewBag.UserId = new SelectList(faUserList, "Id", "Email");
                    return View();
                }
            }
        }

        // GET: Fas/Delete/5
        public ActionResult Delete(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                var fa =
                   (from p in context.Fas
                    where id == p.FaId && !p.DeleteFlag
                    select p).FirstOrDefault();
                if (id == null || fa == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    return View(fa);
                }
            }
        }

        // POST: Fas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Fa fa = context.Fas.Find(id);
                context.Fas.Remove(fa);
                context.SaveChanges();
                transaction.Commit();
                return RedirectToAction("Index");
            }
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
