using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models {
  public class Agency {
    public int Id { get; set; }

    [Display(Name = "Agencija")]
    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Dozvoljeno je maksimalno 50 karaktera!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Dozvoljeno je maksimalno 50 karaktera!")]
    public string Logo { get; set; }
  }
}