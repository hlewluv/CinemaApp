using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaApp.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasRequired(a => a.Account)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice_Detail>()
               .HasRequired(i => i.Invoice) // Specify the navigation property
               .WithOptional() // Optional means one-to-one
               .Map(m => m.MapKey("InvoiceId"));

            modelBuilder.Entity<Invoice_Detail>()
                .HasRequired(t => t.Ticket)
                .WithOptional()
                .Map(m => m.MapKey("TicketId"));

            modelBuilder.Entity<Invoice_Detail>()
                .HasRequired(s => s.ShowDetail)
                .WithOptional()
                .Map(m => m.MapKey("ShowDetailId"));
        }
    }
}