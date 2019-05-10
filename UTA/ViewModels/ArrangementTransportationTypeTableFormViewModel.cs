using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTA.Models;
using System.ComponentModel.DataAnnotations;

namespace UTA.ViewModels
{
  public class ArrangementTransportationTypeTableFormViewModel
  {
    public IEnumerable<Arrangement> Arrangements { get; set; }
    public IEnumerable<TransportationType> TransportationTypes { get; set; }

    public int Id { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Id aranžmana")]
    public int ArrangementId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Id vrste prevoza")]
    public int TransportationTypeId { get; set; }

    public ArrangementTransportationTypeTableFormViewModel()
    {
      Id = 0;
    }

    public ArrangementTransportationTypeTableFormViewModel(ArrangementTransportationType arrangementTransportationType)
    {
      Id = arrangementTransportationType.Id;
      ArrangementId = arrangementTransportationType.ArrangementId;
      TransportationTypeId = arrangementTransportationType.TransportationTypeId;
    }
  }
}