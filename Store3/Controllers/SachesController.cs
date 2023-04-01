using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Store3.Models;

namespace Store3.Controllers
{
    public class SachesController : Controller
    {
        private DbStore db = new DbStore();

        // GET: Saches
        public ActionResult Index(int? page/*, string searchString, int categoryID = 0*/)
        {
            //ViewBag.Keyword = searchString;
            //ViewBag.Subject = categoryID;
            //var sach = db.Saches.Include(b => b.TacGia).Include(b => b.TheLoai).Include(b=>b.NXB);
            //ViewBag.CategoryID = new SelectList(db.Saches, "MaSach", "TenSach");
            //ViewBag.CategoryID = new SelectList(db.TheLoais, "MaTL", "TenTL");
            //ViewBag.CategoryID = new SelectList(db.TacGias, "MaTG", "TenTG");
            //ViewBag.CategoryID = new SelectList(db.NXBs, "MaNXB", "TenNXB");


            if (page == null)
                page = 1;
            int pageSize = 12;

            var saches = db.Saches.Include(s => s.NXB).Include(s => s.TheLoai);

            return View(saches.ToList().ToPagedList(page.Value, pageSize));
        }

        // GET: Saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB");
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,GiaBan,MoTa,HinhAnh,NgayCapNhap,SLTon,MaNXB,MaTL")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,GiaBan,MoTa,HinhAnh,NgayCapNhap,SLTon,MaNXB,MaTL")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNXB = new SelectList(db.NXBs, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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

        //public ActionResult Search(string keyword)
        //{
        //    return View(db.Saches.Where(x => x.TenSach.ToLower().Contains(keyword.ToLower())
        //    || x.TacGia.TenTG.ToLower().Contains(keyword.ToLower())
        //    || x.NXB.TenNXB.ToLower().Contains(keyword.ToLower())
        //    || x.TheLoai.TenTL.ToLower().Contains(keyword.ToLower())).ToList());
        //}



        //public ActionResult ProductByTacGia(int? ID)
        //{
        //    return View(db.Saches.Where(x=>x.MaTG == ID).ToList());
        //}
        //public ActionResult ProductByCategory(int? ID)
        //{
        //    return View(db.Saches.Where(x => x.MaTL == ID).ToList());
        //}
    }
}
