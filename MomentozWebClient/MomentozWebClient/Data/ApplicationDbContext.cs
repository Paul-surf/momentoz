using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MomentozWebClient.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MomentozWebClient.Models.Customer>? Customer { get; set; }
        public DbSet<MomentozWebClient.Models.Flight>? Flight { get; set; }
        public DbSet<MomentozWebClient.Models.Order>? Order { get; set; }
    }
}