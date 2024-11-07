using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class PhieuNhap
    {
        public PhieuNhap()
        {
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }
        [Key]
        public int IdPN { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<bool> DaXoa { get; set; }
        public Nullable<int> IdMLSP { get; set; }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual MaLoaiSanPham MaLoaiSanPham { get; set; }
    }
}