using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Project_63132041.Models;

namespace Project_63132041.Controllers
{
    public class GioHang_63132041Controller : Controller
    {
        private Project_63132041Entities2 db = new Project_63132041Entities2();
        private const string CartSession = "CartSession";

        // GET: GioHang_63132041
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<GioHang_63132041>();
            if (cart != null)
            {
                list = (List<GioHang_63132041>)cart;
            }
            return View(list);
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(string MaSP)
        {
            var sessionCart = (List<GioHang_63132041>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.MaSP == MaSP);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<GioHang_63132041>>(cartModel);
            var sessionCart = (List<GioHang_63132041>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult AddItem(string MaSP, int soluong)
        {
            var sanPham = db.SanPhams.FirstOrDefault(c => c.MaSP == MaSP);
            var GioHang = Session[CartSession];
            if (GioHang != null)
            {
                var list = (List<GioHang_63132041>)GioHang;
                if (list.Exists(x => x.SanPham.MaSP == MaSP))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.MaSP == MaSP)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new GioHang_63132041();
                    item.SanPham = sanPham;
                    item.SoLuong = soluong;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new GioHang_63132041();
                item.SanPham = sanPham;
                item.SoLuong = soluong;
                var list = new List<GioHang_63132041>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return Json(new { status = true });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<GioHang_63132041>();
            if (cart != null)
            {
                list = (List<GioHang_63132041>)cart;
            }
            return View(list);
        }
    }
}
