using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;

namespace UTA.Controllers
{
  public class ArrangementTransportationTypeTableController : Controller
  {
    private ApplicationDbContext _context;

    public ArrangementTransportationTypeTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: ArrangementTransportationTypeTable
    public ActionResult Index()
    {
      var arrangementTransportationTypes = _context.ArrangementTransportationTypes.ToList();

      return View(arrangementTransportationTypes);
    }

    public ActionResult New()
    {
      var arrangementTransportationTypeVM = new ArrangementTransportationTypeTableFormViewModel
      {
        Arrangements = _context.Arrangements.ToList(),
        TransportationTypes = _context.TransportationTypes.ToList()
      };

      return View("ArrangementTransportationTypeTableForm", arrangementTransportationTypeVM);
    }

    public ActionResult Edit(int id)
    {
      var arrangementTransportationType = _context.ArrangementTransportationTypes.SingleOrDefault(d => d.Id == id);

      if (arrangementTransportationType == null)
        return HttpNotFound();

      var arrangementTransportationTypeVM = new ArrangementTransportationTypeTableFormViewModel(arrangementTransportationType)
      {
        Arrangements = _context.Arrangements.ToList(),
        TransportationTypes = _context.TransportationTypes.ToList()
      };

      return View("ArrangementTransportationTypeTableForm", arrangementTransportationTypeVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(ArrangementTransportationTypeTableFormViewModel arrangementTransportationTypeVM)
    {
      if (!ModelState.IsValid)
        return View("ArrangementTransportationTypeTableForm", arrangementTransportationTypeVM);

      if (arrangementTransportationTypeVM.Id == 0)
        _context.ArrangementTransportationTypes.Add(new ArrangementTransportationType {
          ArrangementId = arrangementTransportationTypeVM.ArrangementId,
          TransportationTypeId = arrangementTransportationTypeVM.TransportationTypeId
        });
      else
      {
        var arrangementTransportationTypeInDb = _context.ArrangementTransportationTypes.Single(d => d.Id == arrangementTransportationTypeVM.Id);

        arrangementTransportationTypeInDb.ArrangementId = arrangementTransportationTypeVM.ArrangementId;
        arrangementTransportationTypeInDb.TransportationTypeId = arrangementTransportationTypeVM.TransportationTypeId;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementTransportationTypeTable");
    }

    public ActionResult Delete(int id)
    {
      var arrangementTransportationType = _context.ArrangementTransportationTypes.SingleOrDefault(a => a.Id == id);

      if (arrangementTransportationType == null)
        return HttpNotFound();

      _context.ArrangementTransportationTypes.Remove(arrangementTransportationType);
      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementTransportationTypeTable");
    }
  }
}