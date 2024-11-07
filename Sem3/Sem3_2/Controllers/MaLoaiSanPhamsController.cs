using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sem3_2.Models;

namespace Sem3_2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MaLoaiSanPhamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaLoaiSanPhams
        public async Task<ActionResult> Index()
        {
            return View(await db.MaLoaiSanPhams.ToListAsync());
        }

        // GET: MaLoaiSanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaLoaiSanPham maLoaiSanPham = await db.MaLoaiSanPhams.FindAsync(id);
            if (maLoaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(maLoaiSanPham);
        }

        // GET: MaLoaiSanPhams/Create
        public ActionResult Create(string message)
        {
            ViewBag.message = message;
            return View();
        }

        // POST: MaLoaiSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMLSP,TenLSP,ThongTin,Logo")] MaLoaiSanPham maLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.MaLoaiSanPhams.Add(maLoaiSanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maLoaiSanPham);
        }

        // GET: MaLoaiSanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaLoaiSanPham maLoaiSanPham = await db.MaLoaiSanPhams.FindAsync(id);
            if (maLoaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(maLoaiSanPham);
        }

        // POST: MaLoaiSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMLSP,TenLSP,ThongTin,Logo")] MaLoaiSanPham maLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maLoaiSanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maLoaiSanPham);
        }

        // GET: MaLoaiSanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaLoaiSanPham maLoaiSanPham = await db.MaLoaiSanPhams.FindAsync(id);
            if (maLoaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(maLoaiSanPham);
        }

        // POST: MaLoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MaLoaiSanPham maLoaiSanPham = await db.MaLoaiSanPhams.FindAsync(id);
            db.MaLoaiSanPhams.Remove(maLoaiSanPham);
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
