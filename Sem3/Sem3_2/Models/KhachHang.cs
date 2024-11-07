using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_2.Models
{
    public class KhachHang
    {
        public KhachHang()
        {
            //this.DonDatHangs = new HashSet<DonDatHang>();
        }

        [Key]
        public int IdKH { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        public string TenKhachHang { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email Không hợp lệ!")]
        public string Email { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string IDAccount { get; set; }

        //public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
    }
}