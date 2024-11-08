using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63132041.Models;

namespace Project_63132041.Areas.Admin_63132041.Controllers
{
    public class SanPham_63132041Controller : Controller
    {
        private Project_63132041Entities2 db = new Project_63132041Entities2();

        // GET: Admin_63132041/SanPham_63132041
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanPhams.ToList());
        }

        [HttpGet]
        public ActionResult Index(string MaSP, string TenSP)
        {
            var sanPhams = db.SanPhams.SqlQuery("exec SanPham_TimKiem '" + MaSP + "',N'" + TenSP + "'");
            return View(sanPhams.ToList());
        }

        // GET: Admin_63132041/SanPham_63132041/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin_63132041/SanPham_63132041/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaSP();
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP");
            return View();
        }

        // POST: Admin_63132041/SanPham_63132041/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,MoTaSP,AnhSP,DonGia,Giamgia,Soluong,MaLSP")] SanPham sanPham)
        {
            var imgSP = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
           string postedFileName =System.IO.Path.GetFileName(imgSP.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSP.SaveAs(path);
            if (ModelState.IsValid)
            {
                sanPham.MaSP = LayMaSP();
                sanPham.AnhSP = postedFileName;
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP", sanPham.MaLSP);
            return View(sanPham);
        }

        // GET: Admin_63132041/SanPham_63132041/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP", sanPham.MaLSP);
            return View(sanPham);
        }

        // POST: Admin_63132041/SanPham_63132041/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,MoTaSP,AnhSP,DonGia,Giamgia,Soluong,MaLSP")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP", sanPham.MaLSP);
            return View(sanPham);
        }

        // GET: Admin_63132041/SanPham_63132041/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin_63132041/SanPham_63132041/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
        string LayMaSP()
        {
            var maMax = db.SanPhams.ToList().Select(n => n.MaSP).Max();
            int masp = int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("000", masp.ToString());
            return "SP" + SP.Substring(masp.ToString().Length - 1);
        }

    }
}
