using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class DonHangCT
    {
        [Key]
        public int Id { get; set; }

        public int IdDDH { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}