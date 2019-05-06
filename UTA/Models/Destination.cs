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

    [Display(Name = "Mesto")]
    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Mora biti uneto manje od 50 karaktera!")]
    public string Place { get; set; }

    [Display(Name = "Država")]
    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Mora biti uneto manje od 50 karaktera!")]
    public string Country { get; set; }

    [Display(Name = "Slika")]
    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Mora biti uneto manje od 50 karaktera!")]
    public string Picture { get; set; }
  }
}