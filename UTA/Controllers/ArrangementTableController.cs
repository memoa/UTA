using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;
using System.Data.Entity;

namespace UTA.Controllers
{
  [Authorize]
  public class ArrangementTableController : Controller
  {
    private ApplicationDbContext _context;

    public ArrangementTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: ArrangementTable
    public ActionResult Index()
    {
      var arrangements = _context.Arrangements
        .Include(a => a.Agency)
        .Include(a => a.Destination)
        .Include(a => a.ArrangementType).ToList();

      var transportationTypes = _context.TransportationTypes.ToList();
      var services = _context.Services.ToList();

      var arrangementTransportationTypes = _context.ArrangementTransportationTypes.ToList();
      var arrangementServices = _context.ArrangementServices.ToList();

      var arrangementVMs = new List<ArrangementViewModel>();

      foreach (var arrangement in arrangements)
      {
        var arrangementVM = new ArrangementViewModel(arrangement)
        {
          TransportationTypes = arrangementTransportationTypes
            .Where(art => art.ArrangementId == arrangement.Id)
            .Select(art => transportationTypes.SingleOrDefault(t => t.Id == art.TransportationTypeId)).ToList(),
          Services = arrangementServices
            .Where(ars => ars.ArrangementId == arrangement.Id)
            .Select(ars => services.SingleOrDefault(s => s.Id == ars.ServiceId)).ToList()
        };
        arrangementVMs.Add(arrangementVM);
      }

      return View(arrangementVMs);
    }

    public ActionResult New()
    {
      var arrangement = new Arrangement();

      var arrangementTransportationTypes = _context.ArrangementTransportationTypes.ToList();
      var arrangementServices = _context.ArrangementServices.ToList();

      var arrangementVM = new ArrangementTableFormViewModel(arrangement)
      {
        Agencies = _context.Agencies.ToList(),
        Destinations = _context.Destinations.ToList(),
        ArrangementTypes = _context.ArrangementTypes.ToList(),
        TransportationTypes = _context.TransportationTypes.ToList(),
        Services = _context.Services.ToList(),
        TransporationTypeIds = arrangementTransportationTypes
          .Where(art => art.ArrangementId == arrangement.Id)
          .Select(art => art.TransportationTypeId).ToList(),
        ServiceIds = arrangementServices
          .Where(ars => ars.ArrangementId == arrangement.Id)
          .Select(ars => ars.ServiceId).ToList()
      };

      return View("ArrangementTableForm", arrangementVM);
    }

    public ActionResult Edit(int id)
    {
      var arrangement = _context.Arrangements.SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      var arrangementTransportationTypes = _context.ArrangementTransportationTypes.ToList();
      var arrangementServices = _context.ArrangementServices.ToList();

      var arrangementVM = new ArrangementTableFormViewModel(arrangement)
      {
        Agencies = _context.Agencies.ToList(),
        Destinations = _context.Destinations.ToList(),
        ArrangementTypes = _context.ArrangementTypes.ToList(),
        TransportationTypes = _context.TransportationTypes.ToList(),
        Services = _context.Services.ToList(),
        TransporationTypeIds = arrangementTransportationTypes
          .Where(art => art.ArrangementId == arrangement.Id)
          .Select(art => art.TransportationTypeId).ToList(),
        ServiceIds = arrangementServices
          .Where(ars => ars.ArrangementId == arrangement.Id)
          .Select(ars => ars.ServiceId).ToList()
      };


      return View("ArrangementTableForm", arrangementVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Arrangement arrangement)
    {
      if (!ModelState.IsValid)
      {
        var transportationTypes = _context.TransportationTypes.ToList();
        var services = _context.Services.ToList();

        var arrangementTransportationTypes = _context.ArrangementTransportationTypes.ToList();
        var arrangementServices = _context.ArrangementServices.ToList();

        var arrangementVM = new ArrangementTableFormViewModel(arrangement)
        {
          TransportationTypes = arrangementTransportationTypes
            .Where(art => art.ArrangementId == arrangement.Id)
            .Select(art => transportationTypes.SingleOrDefault(t => t.Id == art.TransportationTypeId)).ToList(),
          Services = arrangementServices
            .Where(ars => ars.ArrangementId == arrangement.Id)
            .Select(ars => services.SingleOrDefault(s => s.Id == ars.ServiceId)).ToList()
        };

        return View("ArrangementTableForm", arrangementVM);
      }

      if (arrangement.Id == 0)
        _context.Arrangements.Add(arrangement);
      else
      {
        var arrangementInDb = _context.Arrangements.Single(a => a.Id == arrangement.Id);

        arrangementInDb.AgencyId = arrangement.AgencyId;
        arrangementInDb.DestinationId = arrangement.DestinationId;
        arrangementInDb.Description = arrangement.Description;
        arrangementInDb.ArrangementTypeId = arrangement.ArrangementTypeId;
        arrangementInDb.StayDays = arrangement.StayDays;
        arrangementInDb.StayNights = arrangement.StayNights;
        arrangementInDb.Price = arrangement.Price;
      }
      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementTable");
    }

    public ActionResult Delete(int id)
    {
      var arrangement = _context.Arrangements.SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      _context.Arrangements.Remove(arrangement);
      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementTable");
    }
  }
}
