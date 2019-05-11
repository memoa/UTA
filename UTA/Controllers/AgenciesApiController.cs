using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTA.Models;

namespace UTA.Controllers
{
  public class AgenciesApiController : ApiController
  {
    private ApplicationDbContext _context;

    public AgenciesApiController()
    {
      _context = new ApplicationDbContext();
    }

    // GET api/agenciesApi
    public IHttpActionResult GetAgencies()
    {
      var agencies = _context.Agencies.ToList();

      return Ok(agencies);
    }

    // GET api/agenciesApi/1
    public IHttpActionResult GetAgency(int id)
    {
      var agency = _context.Agencies.SingleOrDefault(a => a.Id == id);

      if (agency == null)
        return NotFound();

      return Ok(agency);
    }

    // POST api/agenciesApi
    [HttpPost]
    public IHttpActionResult CreateAgency(Agency agency)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      _context.Agencies.Add(agency);
      _context.SaveChanges();

      return Created(new Uri(Request.RequestUri + "/" + agency.Id), agency);
    }

    // PUT api/agenciesApi/1
    [HttpPut]
    public IHttpActionResult UpdateAgency(int id, Agency agency)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var agencyInDb = _context.Agencies.SingleOrDefault(a => a.Id == id);

      if (agencyInDb == null)
        return NotFound();

      agencyInDb.Name = agency.Name;
      agencyInDb.Logo = agency.Logo;

      _context.SaveChanges();

      return Ok();
    }

    [HttpDelete]
    public IHttpActionResult DeleteAgency(int id)
    {
      var agency = _context.Agencies.SingleOrDefault(a => a.Id == id);

      if (agency == null)
        return NotFound();

      _context.Agencies.Remove(agency);
      _context.SaveChanges();

      return Ok();
    }
  }
}
