using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSachLaKho.Models;

namespace QuanLyBanSachLaKho.Controllers
{
    public class MuonSachController : Controller
    {
        private QLLaKhoEntities db = new QLLaKhoEntities();

        // GET: MuonSach
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.KhachHang).Include(d => d.ThanhToan);
            return View(donHangs.ToList());
        }

        // GET: MuonSach/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoDemKH");
            ViewBag.MaHTTT = new SelectList(db.ThanhToans, "MaHTTT", "TenHTTT");
            return View();
        }

        // POST: MuonSach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,NgayDH,GiaDH,NgayGiaoHang,TenNguoiNhan,DiaChiGiao,SdtNguoiNhan,TenNguoiGiao,SdtNguoiGiao,HinhThucGiao,MaKH,MaHTTT")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoDemKH", donHang.MaKH);
            ViewBag.MaHTTT = new SelectList(db.ThanhToans, "MaHTTT", "TenHTTT", donHang.MaHTTT);
            return View(donHang);
        }
    }
}