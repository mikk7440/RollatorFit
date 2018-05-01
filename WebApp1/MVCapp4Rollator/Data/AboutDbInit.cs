using MVCapp4Rollator.Models;
using System;
using System.Linq;

namespace MVCapp4Rollator.Data
{
    public static class AboutDbInit
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //Look for any about Titles
            if (context.AboutModel.Any())
            {
                return; // DB seeded.
            }

            var About = new AboutModel { ID = 0, Title = "Friendly walker - WaLy", Text = "Some exciting text" };

            context.AboutModel.Add(About);           
        }
    }
}