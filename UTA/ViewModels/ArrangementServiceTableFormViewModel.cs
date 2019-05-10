using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTA.Models;
using System.ComponentModel.DataAnnotations;

namespace UTA.ViewModels
{
  public class ArrangementServiceTableFormViewModel
  {
    public IEnumerable<Arrangement> Arrangements { get; set; }
    public IEnumerable<Service> Services { get; set; }

    public int Id { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Id aranžmana")]
    public int ArrangementId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Id usluge")]
    public int ServiceId { get; set; }

    public ArrangementServiceTableFormViewModel()
    {
      Id = 0;
    }

    public ArrangementServiceTableFormViewModel(ArrangementService arrangementService)
    {
      Id = arrangementService.Id;
      ArrangementId = arrangementService.ArrangementId;
      ServiceId = arrangementService.ServiceId;
    }
  }
}