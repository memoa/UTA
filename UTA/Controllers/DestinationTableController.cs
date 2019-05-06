using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;

namespace UTA.Controllers
{
  public class DestinationTableController : Controller
  {

    private ApplicationDbContext _context;

    public DestinationTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: DestinationTable
    public ActionResult Index()
    {
      var destination = _context.Destinations.ToList();

      return View(destination);
    }

    public ActionResult New()
    {
      var destination = new Destination();

      return View("DestinationTableForm", destination);
    }

    public ActionResult Edit(int id)
    {
      var destination = _context.Destinations.SingleOrDefault(d => d.Id == id);

      if (destination == null)
        return HttpNotFound();

      return View("DestinationTableForm", destination);
    }

    public ActionResult Save(Destination destination)
    {
      if (!ModelState.IsValid)
        return View("DestinationTableForm", destination);

      if (destination.Id == 0)
        _context.Destinations.Add(destination);
      else
      {
        var destinationInDb = _context.Destinations.Single(d => d.Id == destination.Id);

        destinationInDb.Place = destination.Place;
        destinationInDb.Country = destination.Country;
        destinationInDb.Picture = destination.Picture;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "DestinationTable");
    }
    public ActionResult Delete(int id)
    {
      var destination = _context.Destinations.SingleOrDefault(a => a.Id == id);

      if (destination == null)
        return HttpNotFound();

      _context.Destinations.Remove(destination);
      _context.SaveChanges();

      return RedirectToAction("Index", "DestinationTable");
    }
  }
}
