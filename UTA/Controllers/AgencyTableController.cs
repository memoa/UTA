using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using System.ComponentModel.DataAnnotations;

namespace UTA.Controllers
{
  [Authorize]
  public class AgencyTableController : Controller
  {
    private ApplicationDbContext _context;

    public AgencyTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: AgencyTable
    public ActionResult Index()
    {
      var agency = _context.Agencies.ToList();

      return View(agency);
    }

    public ActionResult New()
    {
      var agency = new Agency();

      return View("AgencyTableForm", agency);
    }

    public ActionResult Edit(int id)
    {
      var agency = _context.Agencies.SingleOrDefault(d => d.Id == id);

      if (agency == null)
        return HttpNotFound();

      return View("AgencyTableForm", agency);
    }

    public ActionResult Save(Agency agency)
    {
      if (!ModelState.IsValid)
        return View("AgencyTableForm", agency);

      if (agency.Id == 0)
        _context.Agencies.Add(agency);
      else
      {
        var agencyInDb = _context.Agencies.Single(d => d.Id == agency.Id);

        agencyInDb.Name = agency.Name;
        agencyInDb.Logo = agency.Logo;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "AgencyTable");
    }
    public ActionResult Delete(int id)
    {
      var agency = _context.Agencies.SingleOrDefault(a => a.Id == id);

      if (agency == null)
        return HttpNotFound();

      _context.Agencies.Remove(agency);
      _context.SaveChanges();

      return RedirectToAction("Index", "AgencyTable");
    }
  }
}