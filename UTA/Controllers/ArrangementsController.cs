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
        .SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      var transportationTypes = _context.TransportationTypes.ToList();
      var services = _context.Services.ToList();

      var arrangementTransportationTypes = _context.ArrangementTransportationTypes.ToList();
      var arrangementServices = _context.ArrangementServices.ToList();

      var arrangementVM = new ArrangementViewModel(arrangement)
      {
        TransportationTypes = arrangementTransportationTypes
          .Where(art => art.ArrangementId == arrangement.Id)
          .Select(art => transportationTypes.SingleOrDefault(t => t.Id == art.TransportationTypeId)).ToList(),
        Services = arrangementServices
          .Where(ars => ars.ArrangementId == arrangement.Id)
          .Select(ars => services.SingleOrDefault(s => s.Id == ars.ServiceId)).ToList()
      };

      return View(arrangementVM);
    }
  }
}