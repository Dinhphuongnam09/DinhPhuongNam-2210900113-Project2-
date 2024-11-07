using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sem3_2.Models
{
    public class SanPham
    {
        public SanPham()
        {
            this.DonHangCTs = new HashSet<DonHangCT>();
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }
        [Key]
        public int IdSanPham { get; set; }
        [Required]
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSanPham { get; set; }
        [Display(Name = "Đơn Giá")]
        public Nullable<decimal> DonGia { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Cập Nhật")]
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Lượt Xem")]
        public Nullable<int> LuotXem { get; set; }
        [Required]
        [Display(Name = "Loại Sản Phẩm")]
        public Nullable<int> IdLoaiSanPham { get; set; }
        [Display(Name = "Giá Khuyến Mãi")]
        public Nullable<decimal> GiaKhuyenMai { get; set; }
        [Display(Name = "Hình Ảnh 1")]
        public string HinhAnh { get; set; }
        [Display(Name = "Hình Ảnh 2")]
        public string HinhAnh1 { get; set; }
        [Display(Name = "Hình Ảnh 3")]
        public string HinhAnh2 { get; set; }
        [Display(Name = "Đã Xóa")]
        public Nullable<bool> DaXoa { get; set; }
        [Display(Name = "Mới")]
        public Nullable<int> Moi { get; set; }
        [Required]
        [Display(Name = "Loại Sản Phẩm")]
        public Nullable<int> IdMLSP { get; set; }
        [Display(Name = "Số Lượng Tồn")]
        public Nullable<int> SoLuongTon { get; set; }

        public virtual ICollection<DonHangCT> DonHangCTs { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual MaLoaiSanPham MaLoaiSanPham { get; set; }
    }
}