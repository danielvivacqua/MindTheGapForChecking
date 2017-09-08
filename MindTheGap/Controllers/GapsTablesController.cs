using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MindTheGap.Models;

namespace MindTheGap.Controllers
{
    public class GapsTablesController : Controller
    {
        private MindTheGapEntities db = new MindTheGapEntities();

        // GET: GapsTables
        public ActionResult Index()
        {
            return View(db.GapsTables.ToList());
        }

        // GET: GapsTables/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GapsTable gapsTable = db.GapsTables.Find(id);
            if (gapsTable == null)
            {
                return HttpNotFound();
            }
            return View(gapsTable);
        }

        // GET: GapsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GapsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GapStart,GapEnd")] GapsTable gapsTable)
        {
            if (ModelState.IsValid)
            {
                db.GapsTables.Add(gapsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gapsTable);
        }

        // GET: GapsTables/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GapsTable gapsTable = db.GapsTables.Find(id);
            if (gapsTable == null)
            {
                return HttpNotFound();
            }
            return View(gapsTable);
        }

        // POST: GapsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GapStart,GapEnd")] GapsTable gapsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gapsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gapsTable);
        }

        // GET: GapsTables/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GapsTable gapsTable = db.GapsTables.Find(id);
            if (gapsTable == null)
            {
                return HttpNotFound();
            }
            return View(gapsTable);
        }

        // POST: GapsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            GapsTable gapsTable = db.GapsTables.Find(id);
            db.GapsTables.Remove(gapsTable);
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
