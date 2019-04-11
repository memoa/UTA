using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;

namespace UTA.Controllers {
  public class AgenciesController : Controller {
    private ApplicationDbContext _context;

    public AgenciesController() {
      _context = new ApplicationDbContext();
    }

    // GET: Agencies
    public ActionResult Index() {
      var agencies = _context.Agencies.ToList();

      var agenciesVm = new List<AgencyViewModel>();

      foreach (var agency in agencies) {
        var agencyVm = new AgencyViewModel {
          Id = agency.Id,
          Name = agency.Name,
          Logo = agency.Logo
        };

        agenciesVm.Add(agencyVm);
      }

      return View(agenciesVm);
    }

    public ActionResult Details(int id) {
      var agency = _context.Agencies.SingleOrDefault(a => a.Id == id);

      if (agency == null)
        return HttpNotFound();

      return View(agency);
    }
  }
}