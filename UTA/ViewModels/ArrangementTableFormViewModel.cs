using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UTA.Models;

namespace UTA.ViewModels
{
  public class ArrangementTableFormViewModel
  {
    public Agency Agency { get; set; }
    public Destination Destination { get; set; }
    public ArrangementType ArrangementType { get; set; }
    public IEnumerable<TransportationType> TransportationTypes { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public int Id { get; set; }

    public int AgencyId { get; set; }

    public int DestinationId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Opis Aranžmana")]
    public string Description { get; set; }

    public int ArrangementTypeId { get; set; }

    public IEnumerable<int> TransportationTypeIds { get; set; }

    public IEnumerable<int> ServiceIds { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Range(1, 30, ErrorMessage = "Unesite broj između 1 i 30!")]
    [Display(Name = "Broj Dana")]
    public int StayDays { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Range(0, 30, ErrorMessage = "Unesite broj između 0 i 30!")]
    [Display(Name = "Broj Noćenja")]
    public int StayNights { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Range(1, 10000, ErrorMessage = "Unesite broj između 1 i 10000!")]
    [Display(Name = "Cena")]
    public int Price { get; set; }

    public ArrangementTableFormViewModel()
    {
      Id = 0;
    }

    public ArrangementTableFormViewModel(Arrangement arrangement)
    {
      Id = arrangement.Id;
      Agency = arrangement.Agency;
      Destination = arrangement.Destination;
      Description = arrangement.Description;
      ArrangementType = arrangement.ArrangementType;
      StayDays = arrangement.StayDays;
      StayNights = arrangement.StayNights;
      Price = arrangement.Price;
    }
  }
}