using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int IdCTPN { get; set; }
        public Nullable<int> IdPN { get; set; }
        public Nullable<decimal> DonGiaNhap { get; set; }
        public Nullable<int> SoLuongNhap { get; set; }
        public Nullable<int> IdSanPham { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}