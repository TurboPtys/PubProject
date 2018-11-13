using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
            //Seed();
        }

        public DbSet<GastronomicVenue> GastronomicVenues { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        //private void Seed()
        //{
        //    var c = GastronomicVenues.Count();
        //    if (c!=0)
        //    {
        //        GastronomicVenues.Add(new GastronomicVenue { GastronomicVenueId = Guid.NewGuid(), GastronomicVenueName = "Bar Janush" });
        //        GastronomicVenues.Add(new GastronomicVenue { GastronomicVenueId = Guid.NewGuid(), GastronomicVenueName = "Setka" });
        //        SaveChanges();
                
        //    }
        //}
    }
}
