using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class LoaiSanPham
    {
        public LoaiSanPham()
        {
            this.SanPhams = new HashSet<SanPham>();
        }

        [Key]
        public int IdLoaiSanPham { get; set; }
        [Display(Name = "Tên Loại")]
        public string TenLoai { get; set; }
        [Display(Name = "Thông Tin")]
        public string ThongTin { get; set; }
        [Display(Name = "Bí Danh")]
        public string BiDanh { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}