//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_63132041.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHD
    {
        public string SoHD { get; set; }
        public string MaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> DonGiaBan { get; set; }
        public string MaNV { get; set; }
        public string Status { get; set; }
    
        public virtual Nhanvien Nhanvien { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual GioHang GioHang { get; set; }
    }
}
