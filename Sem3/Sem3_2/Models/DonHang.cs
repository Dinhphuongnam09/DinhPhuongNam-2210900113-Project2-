using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class DonHang
    {
        public DonHang()
        {
            this.DonHangCTs = new HashSet<DonHangCT>();
        }
        [Key]
        public int IdDDH { get; set; }
        public System.DateTime NgayDat { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string CachGiao { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection<DonHangCT> DonHangCTs { get; set; }
    }
}