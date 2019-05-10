using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;
using UTA.ViewModels;

namespace UTA.Controllers
{
  [Authorize]
  public class ArrangementServiceTableController : Controller
  {
    private ApplicationDbContext _context;

    public ArrangementServiceTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: ArrangementServiceTable
    public ActionResult Index()
    {
      var arrangementServices = _context.ArrangementServices.ToList();

      return View(arrangementServices);
    }

    public ActionResult New()
    {
      var arrangementServiceVM = new ArrangementServiceTableFormViewModel
      {
        Arrangements = _context.Arrangements.ToList(),
        Services = _context.Services.ToList()
      };

      return View("ArrangementServiceTableForm", arrangementServiceVM);
    }

    public ActionResult Edit(int id)
    {
      var arrangementService = _context.ArrangementServices.SingleOrDefault(d => d.Id == id);

      if (arrangementService == null)
        return HttpNotFound();

      var arrangementServiceVM = new ArrangementServiceTableFormViewModel(arrangementService)
      {
        Arrangements = _context.Arrangements.ToList(),
        Services = _context.Services.ToList()
      };

      return View("ArrangementServiceTableForm", arrangementServiceVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(ArrangementServiceTableFormViewModel arrangementServiceVM)
    {
      if (!ModelState.IsValid)
        return View("ArrangementServiceTableForm", arrangementServiceVM);

      if (arrangementServiceVM.Id == 0)
        _context.ArrangementServices.Add(new ArrangementService
        {
          ArrangementId = arrangementServiceVM.ArrangementId,
          ServiceId = arrangementServiceVM.ServiceId
        });
      else
      {
        var arrangementServiceInDb = _context.ArrangementServices.Single(d => d.Id == arrangementServiceVM.Id);

        arrangementServiceInDb.ArrangementId = arrangementServiceVM.ArrangementId;
        arrangementServiceInDb.ServiceId = arrangementServiceVM.ServiceId;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementServiceTable");
    }

    public ActionResult Delete(int id)
    {
      var arrangementService = _context.ArrangementServices.SingleOrDefault(a => a.Id == id);

      if (arrangementService == null)
        return HttpNotFound();

      _context.ArrangementServices.Remove(arrangementService);
      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementServiceTable");
    }
  }
}