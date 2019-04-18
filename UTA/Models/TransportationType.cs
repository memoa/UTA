using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models {
  public class TransportationType {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
  }
}