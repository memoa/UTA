using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models {
  public class Arrangement {
    public int Id { get; set; }

    public Destination Destination { get; set; }

    public int DestinationId { get; set; }
  }
}