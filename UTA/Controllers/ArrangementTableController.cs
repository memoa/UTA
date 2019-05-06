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
      var arrangements = _context.Arrangements.ToList();

      return View(arrangements);
    }

    public ActionResult New()
    {
      var arrangementVM = new ArrangementViewModel
      {
        Agencies = _context.Agencies.ToList(),
        Destinations = _context.Destinations.ToList(),
        ArrangementTypes = _context.ArrangementTypes.ToList(),
        TransportationTypes = _context.TransportationTypes.ToList(),
        Services = _context.Services.ToList()
      };

      return View("ArrangementTableForm", arrangementVM);
    }

    public ActionResult Edit(int id)
    {
      Arrangement arrangement = _context.Arrangements.SingleOrDefault(a => a.Id == id);

      if (arrangement == null)
        return HttpNotFound();

      var arrangementVM = new ArrangementViewModel(arrangement)
      {
        Agencies = _context.Agencies.ToList(),
        Destinations = _context.Destinations.ToList(),
        ArrangementTypes = _context.ArrangementTypes.ToList(),
        TransportationTypes = _context.TransportationTypes.ToList(),
        Services = _context.Services.ToList()
      };

      return View("ArrangementTableForm", arrangementVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Arrangement arrangement)
    {
      if (!ModelState.IsValid)
      {
        var arrangementVM = new ArrangementViewModel(arrangement)
        {
          Agencies = _context.Agencies.ToList(),
          Destinations = _context.Destinations.ToList(),
          ArrangementTypes = _context.ArrangementTypes.ToList(),
          TransportationTypes = _context.TransportationTypes.ToList(),
          Services = _context.Services.ToList()
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
        arrangementInDb.TransportationTypeId = arrangement.TransportationTypeId;
        arrangementInDb.ServiceId = arrangement.ServiceId;
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
