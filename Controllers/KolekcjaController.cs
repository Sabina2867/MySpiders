using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySpiders;

namespace MySpiders.Controllers
{
    public class KolekcjaController : Controller
    {
        private SpidersEntities db = new SpidersEntities();

        // GET: Kolekcja
        public ActionResult Index()
        {
            return View(db.Kolekcja.ToList());
        }

        // GET: Kolekcja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolekcja kolekcja = db.Kolekcja.Find(id);
            if (kolekcja == null)
            {
                return HttpNotFound();
            }
            return View(kolekcja);
        }

        // GET: Kolekcja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kolekcja/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Gatunek,Ilosc_posiadanych_sztuk,Stadium_pajaka_w_cm,Cena_za_jedna_sztuke")] Kolekcja kolekcja)
        {
            if (ModelState.IsValid)
            {
                db.Kolekcja.Add(kolekcja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kolekcja);
        }

        // GET: Kolekcja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolekcja kolekcja = db.Kolekcja.Find(id);
            if (kolekcja == null)
            {
                return HttpNotFound();
            }
            return View(kolekcja);
        }

        // POST: Kolekcja/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Gatunek,Ilosc_posiadanych_sztuk,Stadium_pajaka_w_cm,Cena_za_jedna_sztuke")] Kolekcja kolekcja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolekcja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kolekcja);
        }

        // GET: Kolekcja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolekcja kolekcja = db.Kolekcja.Find(id);
            if (kolekcja == null)
            {
                return HttpNotFound();
            }
            return View(kolekcja);
        }

        // POST: Kolekcja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolekcja kolekcja = db.Kolekcja.Find(id);
            db.Kolekcja.Remove(kolekcja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Info()
        {
            return View();
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
