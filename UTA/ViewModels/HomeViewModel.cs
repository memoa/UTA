using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTA.Models;

namespace UTA.ViewModels {
  public class HomeViewModel {
    public List<AgencyViewModel> Agencies;
    public List<Arrangement> Arrangements;
  }
}