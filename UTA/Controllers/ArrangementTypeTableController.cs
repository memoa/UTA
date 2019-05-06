using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTA.Models;

namespace UTA.Controllers
{
  [Authorize]
  public class ArrangementTypeTableController : Controller
  {
    private ApplicationDbContext _context;

    public ArrangementTypeTableController()
    {
      _context = new ApplicationDbContext();
    }

    // GET: ArrangementTypeTable
    public ActionResult Index()
    {
      var arrangementType = _context.ArrangementTypes.ToList();

      return View(arrangementType);
    }

    public ActionResult New()
    {
      var arrangementType = new ArrangementType();

      return View("ArrangementTypeTableForm", arrangementType);
    }

    public ActionResult Edit(int id)
    {
      var arrangementType = _context.ArrangementTypes.SingleOrDefault(d => d.Id == id);

      if (arrangementType == null)
        return HttpNotFound();

      return View("ArrangementTypeTableForm", arrangementType);
    }

    public ActionResult Save(ArrangementType arrangementType)
    {
      if (!ModelState.IsValid)
        return View("ArrangementTypeTableForm", arrangementType);

      if (arrangementType.Id == 0)
        _context.ArrangementTypes.Add(arrangementType);
      else
      {
        var arrangementTypeInDb = _context.ArrangementTypes.Single(d => d.Id == arrangementType.Id);

        arrangementTypeInDb.Name = arrangementType.Name;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementTypeTable");
    }
    public ActionResult Delete(int id)
    {
      var arrangementType = _context.ArrangementTypes.SingleOrDefault(a => a.Id == id);

      if (arrangementType == null)
        return HttpNotFound();

      _context.ArrangementTypes.Remove(arrangementType);
      _context.SaveChanges();

      return RedirectToAction("Index", "ArrangementTypeTable");
    }
  }
}