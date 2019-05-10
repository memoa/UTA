using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;
using System.Data.Entity;

namespace UTA.Controllers {
  public class HomeController : Controller {
    private ApplicationDbContext _context;

    public HomeController() {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index() {
      var agencies = _context.Agencies.ToList();
      var arrangements = _context.Arrangements
        .Include(a => a.Destination)
        .Include(a => a.Agency).ToList();

      var homeVm = new HomeViewModel {
        Agencies = agencies,
        Arrangements = arrangements
      };

      return View(homeVm);
    }

    public ActionResult About() {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact() {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}