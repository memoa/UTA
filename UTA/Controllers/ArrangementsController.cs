using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;
using System.Data.Entity;

namespace UTA.Controllers {
  public class ArrangementsController : Controller {
    private ApplicationDbContext _context; 

    public ArrangementsController() {
      _context = new ApplicationDbContext();
    }

    // GET: Arrangements
    public ActionResult Index() {
      var arrangements = _context.Arrangements
        .Include(a => a.Destination)
        .Include(a => a.Agency).ToList();

      return View(arrangements);
    }

    public ActionResult Details(int id) {
      var arrangement = _context.Arrangements
        .Include(a => a.Agency)
        .Include(a => a.Destination)
        .Include(a => a.ArrangementType)
        .Include(a => a.Service)
        .Include(a => a.TransportationType)
        .SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      return View(arrangement);
    }
  }
}