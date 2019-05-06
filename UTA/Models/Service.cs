using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UTA.Models
{
  public class Service
  {
    public int Id { get; set; }

    [Display(Name = "Usluga")]
    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [StringLength(50, ErrorMessage = "Dozvoljeno je maksimalno 50 karaktera!")]
    public string Name { get; set; }
  }
}