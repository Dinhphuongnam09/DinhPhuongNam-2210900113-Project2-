using Sem3_2.DTOs;
using Sem3_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Sem3_2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<SanPham> dsSP = ApplicationDbContext.SanPhams.OrderByDescending(x => x.LuotXem).ToList();
            List<TinTuc> dsTT = ApplicationDbContext.TinTucs.OrderBy(x => x.NgayDang).Take(4).ToList();
            HomeDTO HomeDTO = new HomeDTO();
            HomeDTO.SanPhams = dsSP ?? new List<SanPham>();
            HomeDTO.TinTucs = dsTT ?? new List<TinTuc>();
            return View(HomeDTO);
        }
        public ActionResult productPartialView(string sortString, string logo, string bidanh)
        {
            IEnumerable<SanPham> listTT = ApplicationDbContext.SanPhams
                                .Where(x => x.MaLoaiSanPham.Logo.Equals(logo) && x.LoaiSanPham.BiDanh.Equals(bidanh));
            switch(sortString){
                case "tang":
                    listTT = listTT.OrderBy(x => x.DonGia);
                    break;
                case "giam":
                    listTT = listTT.OrderByDescending(x => x.DonGia);
                    break;
                default:
                    listTT = listTT.OrderByDescending(x => x.LuotXem);
                    break;
            }
            return PartialView("_SubProductPartial", listTT);
        }

        public ActionResult NewsIndex(int id)
        {
            TinTuc tt = ApplicationDbContext.TinTucs.Find(id);
            ViewBag.TinTucMoiNhats = ApplicationDbContext.TinTucs.OrderByDescending(s => s.NgayDang).Where(x => x.IdTinTuc != id).Take(4);
            return View(tt);
        }

        public ActionResult newsPartialView(int offset)
        {
            IEnumerable<TinTuc> listTT = ApplicationDbContext.TinTucs.OrderBy(x => x.NgayDang).Skip(offset).Take(4);
            return PartialView("_NewsPartial", listTT);
        }

        public bool isMore(int offset)
        {
            return offset + 4 >= ApplicationDbContext.TinTucs.Count();
        }

        public ActionResult ProductIndex(int id)
        {
            SanPham tt = ApplicationDbContext.SanPhams.Find(id);
            return View(tt);
        }

        public ActionResult SearchIndex(string searchStringNav)
        {
            List<SanPham> listSP = ApplicationDbContext.SanPhams.Where(x => x.TenSanPham.Contains(searchStringNav)).ToList();
            ViewBag.Count = listSP.Count;
            ViewBag.searchStringNav = searchStringNav;
            return View(listSP);
        }

        public ActionResult searchPartialView(string searchString)
        {
            IEnumerable<SanPhamSearchDTO> listSP = ApplicationDbContext.SanPhams.Where(x => x.TenSanPham.Contains(searchString))
                .Select(x => new SanPhamSearchDTO{idSP = x.IdSanPham, tenSP = x.TenSanPham, hinhanh = x.HinhAnh2, dongia =x.DonGia}).Take(5);
            return PartialView(listSP);
        }
        [HttpPost]
        public JsonResult Checkout(ShoppingCartModel model)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
                DonHang dh = new DonHang();
                dh.HoTen = model.HoTen;
                dh.DiaChi = model.DiaChi;
                dh.DienThoai = model.DienThoai;
                dh.CachGiao = model.CachGiao;
                dh.Email = model.Email;
                dh.NgayDat = DateTime.Today;
                dh.TrangThai = "Chưa giao hàng";
                ApplicationDbContext.DonHangs.Add(dh);
                ApplicationDbContext.SaveChanges();
                int IdDDH = dh.IdDDH;
                for (int i = 0; i < model.CartItems.Count; i++)
                {
                    DonHangCT dhct = new DonHangCT();
                    dhct.IdDDH = IdDDH;
                    dhct.IdSanPham = model.CartItems[i].Id;
                    dhct.SoLuong = model.CartItems[i].Quantity;
                    dhct.DonGia = model.CartItems[i].Price;
                    ApplicationDbContext.DonHangCTs.Add(dhct);

                }
                ApplicationDbContext.SaveChanges();
            //}

            string message = string.Format("Successfully processed {0} item(s).", model.CartItems.Count.ToString());
            return Json(new { Success = true, Message = message });
        }
    }
}