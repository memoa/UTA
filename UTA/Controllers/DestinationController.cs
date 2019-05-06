using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;

namespace UTA.Controllers
{
  public class DestinationController : Controller
  {
    private ApplicationDbContext _context;

    public DestinationController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: Destination
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult New()
    {
      var destination = new Destination();

      return View("DestinationForm", destination);
    }

    public ActionResult Edit(int id)
    {
      var destination = _context.Destinations.SingleOrDefault(d => d.Id == id);

      if (destination == null)
        return HttpNotFound();

      return View("DestinationForm", destination);
    }

    public ActionResult Save(Destination destination)
    {
      if (!ModelState.IsValid)
        return View("DestinationForm", destination);

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

      return RedirectToAction("Index", "Arrangements");
    }
  }
}