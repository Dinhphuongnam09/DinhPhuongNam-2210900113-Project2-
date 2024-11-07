using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Sem3_2.Models;
using PagedList;

namespace Sem3_2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SanPhamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SanPhams
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var sanphams = from t in db.SanPhams
                          select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                sanphams = sanphams.Where(s => s.TenSanPham.Contains(searchString)
                                       || s.MaLoaiSanPham.TenLSP.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    sanphams = sanphams.OrderByDescending(s => s.TenSanPham);
                    break;
                case "Date":
                    sanphams = sanphams.OrderBy(s => s.NgayCapNhat);
                    break;
                case "date_desc":
                    sanphams = sanphams.OrderByDescending(s => s.NgayCapNhat);
                    break;
                default:
                    sanphams = sanphams.OrderBy(s => s.TenSanPham);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(sanphams.ToPagedList(pageNumber, pageSize));
        }
        

        // GET: SanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            if (!db.LoaiSanPhams.Any())
            {
                return RedirectToAction("Create", "LoaiSanPhams",
                    new { message = "Danh sách loại sản phẩm đang trống, thêm loại sản phẩm trước khi thêm sản phẩm!"});
            }
            if (!db.MaLoaiSanPhams.Any())
            {
                return RedirectToAction("Create", "MaLoaiSanPhams",
                    new { message = "Danh sách mã loại sản phẩm đang trống, thêm loại sản phẩm trước khi thêm sản phẩm!"});
            }
            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "IdLoaiSanPham", "TenLoai");
            ViewBag.IdMLSP = new SelectList(db.MaLoaiSanPhams, "IdMLSP", "TenLSP");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdSanPham,TenSanPham,DonGia,NgayCapNhat,MoTa,LuotXem,IdLoaiSanPham,GiaKhuyenMai,HinhAnh,HinhAnh1,HinhAnh2,DaXoa,Moi,IdMLSP,SoLuongTon")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "IdLoaiSanPham", "TenLoai", sanPham.IdLoaiSanPham);
            ViewBag.IdMLSP = new SelectList(db.MaLoaiSanPhams, "IdMLSP", "TenLSP", sanPham.IdMLSP);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "IdLoaiSanPham", "TenLoai", sanPham.IdLoaiSanPham);
            ViewBag.IdMLSP = new SelectList(db.MaLoaiSanPhams, "IdMLSP", "TenLSP", sanPham.IdMLSP);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdSanPham,TenSanPham,DonGia,NgayCapNhat,MoTa,LuotXem,IdLoaiSanPham,GiaKhuyenMai,HinhAnh,HinhAnh1,HinhAnh2,DaXoa,Moi,IdMLSP,SoLuongTon")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "IdLoaiSanPham", "TenLoai", sanPham.IdLoaiSanPham);
            ViewBag.IdMLSP = new SelectList(db.MaLoaiSanPhams, "IdMLSP", "TenLSP", sanPham.IdMLSP);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            db.SanPhams.Remove(sanPham);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
