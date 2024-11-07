using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class MaLoaiSanPham
    {
        public MaLoaiSanPham()
        {
            this.PhieuNhaps = new HashSet<PhieuNhap>();
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        public int IdMLSP { get; set; }
        [Display(Name = "Tên Mã Sản Phẩm")]
        public string TenLSP { get; set; }
        [Display(Name = "Thông Tin")]
        public string ThongTin { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}