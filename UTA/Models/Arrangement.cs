using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models {
  public class Arrangement {
    public int Id { get; set; }

    public Agency Agency { get; set; }

    public int AgencyId { get; set; }

    public Destination Destination { get; set; }

    public int DestinationId { get; set; }

    [Required]
    [StringLength(5000)]
    public string Description { get; set; }

    public ArrangementType ArrangementType { get; set; }

    public int ArrangementTypeId { get; set; }

    [Range(1, 30)]
    public int StayDays { get; set; }

    [Range(0, 30)]
    public int StayNights { get; set; }

    [Range(1, 10000)]
    public int Price { get; set; }
  }
}