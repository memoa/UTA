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

      var arrangementVM = new ArrangementTableFormViewModel(arrangement)
      {
        Agencies = _context.Agencies.ToList(),
        Destinations = _context.Destinations.ToList(),
        ArrangementTypes = _context.ArrangementTypes.ToList()
      };

      return View("ArrangementTableForm", arrangementVM);
    }

    public ActionResult Edit(int id)
    {
      var arrangement = _context.Arrangements.SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      var arrangementVM = new ArrangementTableFormViewModel(arrangement)
      {
        Agencies = _context.Agencies.ToList(),
        Destinations = _context.Destinations.ToList(),
        ArrangementTypes = _context.ArrangementTypes.ToList(),
      };


      return View("ArrangementTableForm", arrangementVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(ArrangementTableFormViewModel arrangementVM)
    {
      if (!ModelState.IsValid)
        return View("ArrangementTableForm", arrangementVM);

      if (arrangementVM.Id == 0)
      {
        var arrangement = new Arrangement
        {
          AgencyId = arrangementVM.AgencyId,
          DestinationId = arrangementVM.DestinationId,
          Description = arrangementVM.Description,
          ArrangementTypeId = arrangementVM.ArrangementTypeId,
          StayDays = arrangementVM.StayDays,
          StayNights = arrangementVM.StayNights,
          Price = arrangementVM.Price
        };

        _context.Arrangements.Add(arrangement);
      }
      else
      {
        var arrangementInDb = _context.Arrangements.Single(a => a.Id == arrangementVM.Id);

        arrangementInDb.AgencyId = arrangementVM.AgencyId;
        arrangementInDb.DestinationId = arrangementVM.DestinationId;
        arrangementInDb.Description = arrangementVM.Description;
        arrangementInDb.ArrangementTypeId = arrangementVM.ArrangementTypeId;
        arrangementInDb.StayDays = arrangementVM.StayDays;
        arrangementInDb.StayNights = arrangementVM.StayNights;
        arrangementInDb.Price = arrangementVM.Price;
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
