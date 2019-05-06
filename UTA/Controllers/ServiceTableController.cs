using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;

namespace UTA.Controllers
{
  [Authorize]
  public class ServiceTableController : Controller
  {
    private ApplicationDbContext _context;

    public ServiceTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: ServiceTable
    public ActionResult Index()
    {
      var service = _context.Services.ToList();

      return View(service);
    }

    public ActionResult New()
    {
      var service = new Service();

      return View("ServiceTableForm", service);
    }

    public ActionResult Edit(int id)
    {
      var service = _context.Services.SingleOrDefault(d => d.Id == id);

      if (service == null)
        return HttpNotFound();

      return View("ServiceTableForm", service);
    }

    public ActionResult Save(Service service)
    {
      if (!ModelState.IsValid)
        return View("ServiceTableForm", service);

      if (service.Id == 0)
        _context.Services.Add(service);
      else
      {
        var serviceInDb = _context.Services.Single(d => d.Id == service.Id);

        serviceInDb.Name = service.Name;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "ServiceTable");
    }
    public ActionResult Delete(int id)
    {
      var service = _context.Services.SingleOrDefault(a => a.Id == id);

      if (service == null)
        return HttpNotFound();

      _context.Services.Remove(service);
      _context.SaveChanges();

      return RedirectToAction("Index", "ServiceTable");
    }
  }
}