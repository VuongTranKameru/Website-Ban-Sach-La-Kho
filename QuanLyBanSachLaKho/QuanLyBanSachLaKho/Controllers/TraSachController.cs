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
    public class TraSachController : Controller
    {
        private QLLaKhoEntities db = new QLLaKhoEntities();

        // GET: MuonSach
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.KhachHang).Include(d => d.ThanhToan);
            return View(donHangs.ToList());
        }
    }
}