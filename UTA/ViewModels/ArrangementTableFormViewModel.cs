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
    public IEnumerable<Agency> Agencies { get; set; }
    public IEnumerable<Destination> Destinations { get; set; }
    public IEnumerable<ArrangementType> ArrangementTypes { get; set; }
    public IEnumerable<TransportationType> TransportationTypes { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public int Id { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Agencija")]
    public int AgencyId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Destinacija")]
    public int DestinationId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Opis Aranžmana")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Tip aranžmana")]
    public int ArrangementTypeId { get; set; }

    public IEnumerable<int> TransporationTypeIds { get; set; }

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
      AgencyId = arrangement.AgencyId;
      DestinationId = arrangement.DestinationId;
      Description = arrangement.Description;
      ArrangementTypeId = arrangement.ArrangementTypeId;
      //TransporationTypeIds = new List<int>();
      //ServiceIds = new List<int>();
      StayDays = arrangement.StayDays;
      StayNights = arrangement.StayNights;
      Price = arrangement.Price;
    }
  }
}