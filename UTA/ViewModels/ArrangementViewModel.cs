using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTA.Models;
using System.ComponentModel.DataAnnotations;

namespace UTA.ViewModels {
  public class ArrangementViewModel {
    public IEnumerable<Destination> Destinations { get; set; }
    public IEnumerable<ArrangementType> ArrangementTypes { get; set; }
    public IEnumerable<TransportationType> TransportationTypes { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public int Id { get; set; }
    [Display(Name = "Destinacija")]
    public int DestinationId { get; set; }
    [Display(Name = "Opis Aranžmana")]
    public string Description { get; set; }
    [Display(Name = "Tip Aranžmana")]
    public int ArrangementTypeId { get; set; }
    [Display(Name = "Tip Prevoza")]
    public int TransportationTypeId { get; set; }
    [Display(Name = "Usluga")]
    public int ServiceId { get; set; }
    [Display(Name = "Broj Dana")]
    public int StayDays { get; set; }
    [Display(Name = "Broj Noćenja")]
    public int StayNights { get; set; }
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