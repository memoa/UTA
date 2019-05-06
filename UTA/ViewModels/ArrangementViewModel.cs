using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTA.Models;
using System.ComponentModel.DataAnnotations;

namespace UTA.ViewModels {
  public class ArrangementViewModel {
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
    [Display(Name = "Tip Aranžmana")]
    public int ArrangementTypeId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Tip Prevoza")]
    public int TransportationTypeId { get; set; }

    [Required(ErrorMessage = "Ovo polje je obavezno!")]
    [Display(Name = "Usluga")]
    public int ServiceId { get; set; }

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

    public ArrangementViewModel()
    {
      Id = 0;
    }
    public ArrangementViewModel(Arrangement arrangement)
    {
      Id = arrangement.Id;
      DestinationId = arrangement.DestinationId;
      Description = arrangement.Description;
      ArrangementTypeId = arrangement.ArrangementTypeId;
      TransportationTypeId = arrangement.TransportationTypeId;
      ServiceId = arrangement.ServiceId;
      StayDays = arrangement.StayDays;
      StayNights = arrangement.StayNights;
      Price = arrangement.Price;
    }
  }
}