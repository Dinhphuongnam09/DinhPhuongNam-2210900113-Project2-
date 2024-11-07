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
    public class TinTucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TinTucs
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

            var tintucs = from t in db.TinTucs
                           select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tintucs = tintucs.Where(s => s.TieuDe.Contains(searchString)
                                       || s.NoiDung.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    tintucs = tintucs.OrderByDescending(s => s.TieuDe);
                    break;
                case "Date":
                    tintucs = tintucs.OrderBy(s => s.NgayDang);
                    break;
                case "date_desc":
                    tintucs = tintucs.OrderByDescending(s => s.NgayDang);
                    break;
                default:
                    tintucs = tintucs.OrderBy(s => s.TieuDe);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(tintucs.ToPagedList(pageNumber, pageSize));
        }

        // GET: TinTucs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = await db.TinTucs.FindAsync(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: TinTucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TinTucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTinTuc,TieuDe,NoiDung,HinhAnhDaiDien,Moi,NoiBat,NgayDang,MoTa")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                db.TinTucs.Add(tinTuc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tinTuc);
        }

        // GET: TinTucs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = await db.TinTucs.FindAsync(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: TinTucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTinTuc,TieuDe,NoiDung,HinhAnhDaiDien,Moi,NoiBat,NgayDang,MoTa")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinTuc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tinTuc);
        }

        // GET: TinTucs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = await db.TinTucs.FindAsync(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TinTuc tinTuc = await db.TinTucs.FindAsync(id);
            db.TinTucs.Remove(tinTuc);
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
