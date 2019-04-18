using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models
{
  public class Destination
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Place { get; set; }

    [Required]
    [StringLength(50)]
    public string Country { get; set; }

    [Required]
    [StringLength(50)]
    public string Picture { get; set; }
  }
}