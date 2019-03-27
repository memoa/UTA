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

      return View(agencies);
    }
  }
}