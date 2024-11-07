using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sem3_2.Models;

namespace Sem3_2.DTOs
{
    public class HomeDTO
    {
        public ICollection<SanPham> SanPhams { get; set; }
        public ICollection<TinTuc> TinTucs { get; set; }
    }
}