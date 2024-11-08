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
    public class login_63132041Controller : Controller
    {
        private Project_63132041Entities2 db = new Project_63132041Entities2();

        // GET: Admin_63132041/login_63132041
        public ActionResult Index()
        {
            return View(db.Nguoidungs.ToList());
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)//FormCollection nhận dữ liệu đăng nhập từ giao diện người dùng
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.Nguoidungs.SingleOrDefault(x => x.Email.Equals(userMail) && x.Password.Equals(password));
            if (islogin != null)
            {
                if (userMail == "Admin@gmail.com")
                {
                    Session["user"] = islogin;
                    return RedirectToAction("Index","SanPham_63132041");
                }
                else
                {

                    Session["user"] = islogin;
                    return RedirectToAction("Index", "SanPhams_63132041", new { area = "" });

                }
            }
            else
            {
                ViewBag.Fail = "Đăng Nhập thất bại";
                return View();
            }


        }
        public ActionResult DangXuat()
        {
            Session["user"] = null;
            return RedirectToAction("DangNhap");
        }
       


    }
}

