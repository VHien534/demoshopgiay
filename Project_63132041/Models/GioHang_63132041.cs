using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63132041.Models
{
    [Serializable]
    public class GioHang_63132041
    {
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public SanPham SanPham { get; set; }
    }
}