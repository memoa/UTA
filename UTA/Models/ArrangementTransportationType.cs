using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTA.Models
{
  public class ArrangementTransportationType
  {
    public int Id { get; set; }

    public Arrangement Arrangement { get; set; }

    public int ArrangementId { get; set; }

    public TransportationType TransportationType { get; set; }

    public int TransportationTypeId { get; set; }
  }
}