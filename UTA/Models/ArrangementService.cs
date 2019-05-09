using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTA.Models
{
  public class ArrangementService
  {
    public int Id { get; set; }

    public Arrangement Arrangement { get; set; }

    public int ArrangementId { get; set; }

    public Service Service { get; set; }

    public int ServiceId { get; set; }
  }
}