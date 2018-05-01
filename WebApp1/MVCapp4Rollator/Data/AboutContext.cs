using MVCapp4Rollator.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCapp4Rollator.Data
{
    public class AboutContext : DbContext
    {
        public AboutContext(DbContextOptions<AboutContext> options) : base(options)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutModel>().ToString();
        }

    }
}
