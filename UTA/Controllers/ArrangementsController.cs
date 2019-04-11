using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;

namespace UTA.Controllers {
  public class ArrangementsController : Controller {
    private ApplicationDbContext _context; 

    public ArrangementsController() {
      _context = new ApplicationDbContext();
    }

    // GET: Arrangements
    public ActionResult Index() {
      var arrangements = _context.Arrangements.ToList();

      var arrangementsVm = new List<ArrangementViewModel>();

      foreach (var arrangement in arrangements) {
        var arrangementVm = new ArrangementViewModel {
          Id = arrangement.Id,
          Destination = arrangement.Destination,
          Picture = arrangement.Picture
        };

        arrangementsVm.Add(arrangementVm);
      }

      return View(arrangementsVm);
    }

    public ActionResult Details(int id) {
      var arrangement = _context.Arrangements.SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      return View(arrangement);
    }
  }
}