using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models
{
  public class TransportationType
  {
    public int Id { get; set; }

    [Display(Name = "Vrsta prevoza")]
    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Dozvojeno je maksimalno 50 karaktera!")]
    public string Name { get; set; }
  }
}