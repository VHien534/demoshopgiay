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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietHDs = new HashSet<ChiTietHD>();
        }
    
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTaSP { get; set; }
        public string AnhSP { get; set; }
        public Nullable<int> DonGia { get; set; }
        public string Giamgia { get; set; }
        public string Soluong { get; set; }
        public string MaLSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
