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
      var arrangements = _context.Arrangements.Include(a => a.Destination).ToList();
      /*
      var arrangementsVm = new List<ArrangementViewModel>();

      foreach (var arrangement in arrangements) {
        var arrangementVm = new ArrangementViewModel {
          Id = arrangement.Id,
          Destination = arrangement.Destination,
          Picture = arrangement.Picture
        };

        arrangementsVm.Add(arrangementVm);
      }
      */
      return View(arrangements);
    }

    public ActionResult Details(int id) {
      var arrangement = _context.Arrangements
        .Include(a => a.Destination)
        .Include(a => a.ArrangementType)
        .Include(a => a.Service)
        .Include(a => a.TransportationType)
        .SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      return View(arrangement);
    }

    public ActionResult New()
    {
      var destinations = _context.Destinations.ToList();
      var arrangementTypes = _context.ArrangementTypes.ToList();
      var transportationTypes = _context.TransportationTypes.ToList();
      var services = _context.Services.ToList();

      var arrangementVM = new ArrangementViewModel {
        Destinations = destinations,
        ArrangementTypes = arrangementTypes,
        TransportationTypes = transportationTypes,
        Services = services
      };

      return View("ArrangementForm", arrangementVM);
    }
  }
}