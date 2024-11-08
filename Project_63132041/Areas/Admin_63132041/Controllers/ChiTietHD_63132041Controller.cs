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
    public class ChiTietHD_63132041Controller : Controller
    {
        private Project_63132041Entities2 db = new Project_63132041Entities2();

        // GET: Admin_63132041/ChiTietHD_63132041
        public ActionResult Index()
        {
            var pendingOrders = db.ChiTietHDs.Where(o => o.Status == "Pending").ToList();
            return View(pendingOrders);
        }

        // POST: Admin/ConfirmOrder
        [HttpPost]
        public ActionResult ConfirmOrder(string id)
        {
            var order = db.ChiTietHDs.Find(id);
            if (order != null)
            {
                order.Status = "Confirmed";
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Order not found." });
        }

        // POST: Admin/CancelOrder
        [HttpPost]
        public ActionResult CancelOrder(string id)
        {
            var order = db.ChiTietHDs.Find(id);
            if (order != null)
            {
                order.Status = "Cancelled";
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Order not found." });
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
