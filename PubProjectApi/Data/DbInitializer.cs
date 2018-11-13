using PubProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();


            var gastroVenuses = new GastronomicVenue[]
            {
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Bar Janush",Active=true,City="Warszawa",HouseNr=11,Phone="512369001",Street="Pasaż Stokłosy"},
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Bar Remont",Active=true,City="Wrocław",HouseNr=18,Phone="123456789",Street="plac Grunwaldzki"}
            };

            if (!context.GastronomicVenues.Any())
            {
                foreach (GastronomicVenue g in gastroVenuses)
                {
                    context.GastronomicVenues.Add(g);
                }
                context.SaveChanges();

            }

            var advertisments = new Advertisement[]
            {
                new Advertisement {AdvertisementId=Guid.NewGuid(),Active=true,DateAdded=DateTime.Now,Title="Koncert TPN25",
                    Description ="Dnia 25 odbędize się koncert zespołu TPN25 w barze Janush o 18:30",Tag="Muzyka",GastronomicVenue = gastroVenuses.Where(x =>x.GastronomicVenueName.Equals("Bar Janush")).FirstOrDefault()},
                new Advertisement {AdvertisementId=Guid.NewGuid(),Active=true,DateAdded=DateTime.Now,Title="Wortki za Piątaka",
                    Description ="W każdy Wtorek duże piwo tylko 5 zł", Tag="Promocja",GastronomicVenue = gastroVenuses.Where(x =>x.GastronomicVenueName.Equals("Bar Remont")).FirstOrDefault()}

            };

            if (!context.Advertisements.Any())
            {

                foreach (Advertisement a in advertisments)
                {
                    context.Advertisements.Add(a);
                }
                context.SaveChanges();
            }

        }
    }
}
