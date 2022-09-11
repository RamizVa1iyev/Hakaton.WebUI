using Hakaton.WebUI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Panel> Panels { get; set; }

        public DbSet<Batery> Bateries { get; set; }

        public DbSet<MainStorage> MainStorages { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}