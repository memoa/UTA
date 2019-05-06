using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;

namespace UTA.Controllers
{
  public class TransportationTypeTableController : Controller
  {
    private ApplicationDbContext _context;

    public TransportationTypeTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: TransportationTypeTable
    public ActionResult Index()
    {
      var transportationType = _context.TransportationTypes.ToList();

      return View(transportationType);
    }

    public ActionResult New()
    {
      var transportationType = new TransportationType();

      return View("TransportationTypeTableForm", transportationType);
    }

    public ActionResult Edit(int id)
    {
      var transportationType = _context.TransportationTypes.SingleOrDefault(d => d.Id == id);

      if (transportationType == null)
        return HttpNotFound();

      return View("TransportationTypeTableForm", transportationType);
    }

    public ActionResult Save(TransportationType transportationType)
    {
      if (!ModelState.IsValid)
        return View("TransportationTypeTableForm", transportationType);

      if (transportationType.Id == 0)
        _context.TransportationTypes.Add(transportationType);
      else
      {
        var transportationTypeInDb = _context.TransportationTypes.Single(d => d.Id == transportationType.Id);

        transportationTypeInDb.Name = transportationType.Name;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "TransportationTypeTable");
    }
    public ActionResult Delete(int id)
    {
      var transportationType = _context.TransportationTypes.SingleOrDefault(a => a.Id == id);

      if (transportationType == null)
        return HttpNotFound();

      _context.TransportationTypes.Remove(transportationType);
      _context.SaveChanges();

      return RedirectToAction("Index", "TransportationTypeTable");
    }
  }
}