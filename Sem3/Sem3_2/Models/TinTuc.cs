using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class TinTuc
    {
        [Key]
        public int IdTinTuc { get; set; }
        [Display(Name = "Tiêu Đề")]
        public string TieuDe { get; set; }
        public string TieuDeRutGon
        {
            get
            {
                return TieuDe.Length > 10 ? TieuDe.Substring(0, 10) + "..." : TieuDe;
            }
        }
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }
        public string NoiDungRutGon
        {
            get
            {
                return NoiDung.Length > 10 ? NoiDung.Substring(0, 10) + "..." : NoiDung;
            }
        }

        public string NoiDungRutGonNews
        {
            get
            {
                return NoiDung.Length > 56 ? NoiDung.Substring(0, 56) + "..." : NoiDung;
            }
        }

        public string NoiDungRutGonHome
        {
            get
            {
                return NoiDung.Length > 365 ? NoiDung.Substring(0, 365) + "..." : NoiDung;
                
            }
        }
        [Display(Name = "Hình Ảnh Đại Diện")]
        public string HinhAnhDaiDien { get; set; }
        [Display(Name = "Mới")]
        public Nullable<bool> Moi { get; set; }
        [Display(Name = "Nổi Bật")]
        public Nullable<bool> NoiBat { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Đăng")]
        public Nullable<System.DateTime> NgayDang { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        
    }
}