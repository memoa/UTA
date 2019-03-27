using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UTA.Models {
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Arrangement> Arrangements { get; set; }

    /*
    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
    */

    

    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false) {
    }

    public static ApplicationDbContext Create() {
      return new ApplicationDbContext();
    }
  }
}