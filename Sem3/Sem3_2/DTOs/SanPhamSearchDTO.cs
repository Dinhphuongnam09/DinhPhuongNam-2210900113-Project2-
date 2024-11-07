using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_2.DTOs
{
    public class SanPhamSearchDTO
    {
        public int idSP { get; set; }
        public string tenSP { get; set; }
        public string hinhanh { get; set; }
        public decimal? dongia { get; set; }
    }
}