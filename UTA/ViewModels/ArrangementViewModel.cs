using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTA.Models;
using System.ComponentModel.DataAnnotations;

namespace UTA.ViewModels {
  public class ArrangementViewModel {
    public IEnumerable<TransportationType> TransportationTypes { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public int Id { get; set; }
    public Agency Agency { get; set; }
    public Destination Destination { get; set; }
    public string Description { get; set; }
    public ArrangementType ArrangementType { get; set; }
    public int StayDays { get; set; }
    public int StayNights { get; set; }
    public int Price { get; set; }

    public ArrangementViewModel(Arrangement arrangement)
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