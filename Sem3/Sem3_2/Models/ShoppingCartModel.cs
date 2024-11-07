using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_2.Models
{
    public class ShoppingCartModel
    {
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string CachGiao { get; set; }
        public string TrangThai { get; set; }
        public List<CartItemModel> CartItems { get; set; }
    }
}