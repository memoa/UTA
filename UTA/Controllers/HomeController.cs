using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;

namespace UTA.Controllers {
  public class HomeController : Controller {
    private ApplicationDbContext _context;

    public HomeController() {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index() {
      var agencies = _context.Agencies.ToList();
      var arrangements = _context.Arrangements.ToList();

      HomeViewModel homeVm = new HomeViewModel {
        Agencies = new List<AgencyViewModel>(),
        Arrangements = new List<ArrangementViewModel>()
      };

      foreach (var agency in agencies) {
        var agencyVm = new AgencyViewModel {
          Id = agency.Id,
          Name = agency.Name,
          Logo = agency.Logo
        };

        homeVm.Agencies.Add(agencyVm);
      }

      foreach (var arrangement in arrangements) {
        var arrangementVm = new ArrangementViewModel {
          Id = arrangement.Id,
          Destination = arrangement.Destination,
          Picture = arrangement.Picture
        };

        homeVm.Arrangements.Add(arrangementVm);
      }

      return View(homeVm);
    }

    public ActionResult About() {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact() {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}