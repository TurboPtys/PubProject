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
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Bar Janush",Active=true,City="Warszawa",HouseNr=11,Phone="512369001",Street="Pasaż Stokłosy", LocalNr=5, PostCode="02-787", Latitude=52.1616054, Longitude=21.0275685, GastronomicVenueDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eu ante velit. Nulla ipsum velit, cursus quis aliquam ac, hendrerit sed eros. Maecenas accumsan gravida est sit amet dignissim. Nullam vitae ligula elit. Curabitur congue maximus mi. Fusce quis ligula vulputate ligula gravida ultrices a sollicitudin nulla. Proin fringilla cursus magna, at consectetur nulla vulputate nec. Fusce dolor turpis, lacinia id maximus et, condimentum nec massa. Donec quis porttitor lorem. Integer congue turpis sapien, eget tincidunt elit suscipit nec. Duis sed enim eu dui dapibus commodo vitae pharetra turpis. Maecenas rutrum tristique massa eu posuere. Aliquam facilisis velit nec ante pretium, consectetur dapibus elit laoreet. Aliquam erat volutpat.In ut ligula volutpat, consectetur turpis eget, volutpat nulla. Donec elit justo, cursus in elit vitae, faucibus volutpat diam. Integer ipsum metus, varius nec tristique vitae, scelerisque non risus. Maecenas ut urna libero. Praesent ut dictum est. Pellentesque rutrum placerat est, sed."},
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Remont Bar",Active=true,City="Wrocław",HouseNr=18,Phone="123456789",Street="plac Grunwaldzki", PostCode="50-370", Latitude=51.1114858, Longitude=17.0564206,GastronomicVenueDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eu ante velit. Nulla ipsum velit, cursus quis aliquam ac, hendrerit sed eros. Maecenas accumsan gravida est sit amet dignissim. Nullam vitae ligula elit. Curabitur congue maximus mi. Fusce quis ligula vulputate ligula gravida ultrices a sollicitudin nulla. Proin fringilla cursus magna, at consectetur nulla vulputate nec. Fusce dolor turpis, lacinia id maximus et, condimentum nec massa. Donec quis porttitor lorem. Integer congue turpis sapien, eget tincidunt elit suscipit nec. Duis sed enim eu dui dapibus commodo vitae pharetra turpis. Maecenas rutrum tristique massa eu posuere. Aliquam facilisis velit nec ante pretium, consectetur dapibus elit laoreet. Aliquam erat volutpat.In ut ligula volutpat, consectetur turpis eget, volutpat nulla. Donec elit justo, cursus in elit vitae, faucibus volutpat diam. Integer ipsum metus, varius nec tristique vitae, scelerisque non risus. Maecenas ut urna libero. Praesent ut dictum est. Pellentesque rutrum placerat est, sed."},
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Bar Reset",Active=true,City="Wrocław",HouseNr=20,Phone="123456789",Street="Grunwaldzka", PostCode="50-370", Latitude=51.1114858, Longitude=17.0564206,GastronomicVenueDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eu ante velit. Nulla ipsum velit, cursus quis aliquam ac, hendrerit sed eros. Maecenas accumsan gravida est sit amet dignissim. Nullam vitae ligula elit. Curabitur congue maximus mi. Fusce quis ligula vulputate ligula gravida ultrices a sollicitudin nulla. Proin fringilla cursus magna, at consectetur nulla vulputate nec. Fusce dolor turpis, lacinia id maximus et, condimentum nec massa. Donec quis porttitor lorem. Integer congue turpis sapien, eget tincidunt elit suscipit nec. Duis sed enim eu dui dapibus commodo vitae pharetra turpis. Maecenas rutrum tristique massa eu posuere. Aliquam facilisis velit nec ante pretium, consectetur dapibus elit laoreet. Aliquam erat volutpat.In ut ligula volutpat, consectetur turpis eget, volutpat nulla. Donec elit justo, cursus in elit vitae, faucibus volutpat diam. Integer ipsum metus, varius nec tristique vitae, scelerisque non risus. Maecenas ut urna libero. Praesent ut dictum est. Pellentesque rutrum placerat est, sed."},
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Setka Bar",Active=true,City="Wrocław",HouseNr=7,Phone="123456789",Street="Stanisława Leszczyńskiego", PostCode="50-077", Latitude=51.107707, Longitude=17.0294443,GastronomicVenueDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eu ante velit. Nulla ipsum velit, cursus quis aliquam ac, hendrerit sed eros. Maecenas accumsan gravida est sit amet dignissim. Nullam vitae ligula elit. Curabitur congue maximus mi. Fusce quis ligula vulputate ligula gravida ultrices a sollicitudin nulla. Proin fringilla cursus magna, at consectetur nulla vulputate nec. Fusce dolor turpis, lacinia id maximus et, condimentum nec massa. Donec quis porttitor lorem. Integer congue turpis sapien, eget tincidunt elit suscipit nec. Duis sed enim eu dui dapibus commodo vitae pharetra turpis. Maecenas rutrum tristique massa eu posuere. Aliquam facilisis velit nec ante pretium, consectetur dapibus elit laoreet. Aliquam erat volutpat.In ut ligula volutpat, consectetur turpis eget, volutpat nulla. Donec elit justo, cursus in elit vitae, faucibus volutpat diam. Integer ipsum metus, varius nec tristique vitae, scelerisque non risus. Maecenas ut urna libero. Praesent ut dictum est. Pellentesque rutrum placerat est, sed."},
                new GastronomicVenue {GastronomicVenueId=Guid.NewGuid(),GastronomicVenueName="Czupito",Active=true,City="Wrocław",HouseNr=8,Phone="123456789",Street="Ruska", PostCode="50-079", Latitude=51.1101694, Longitude=17.0277448,GastronomicVenueDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eu ante velit. Nulla ipsum velit, cursus quis aliquam ac, hendrerit sed eros. Maecenas accumsan gravida est sit amet dignissim. Nullam vitae ligula elit. Curabitur congue maximus mi. Fusce quis ligula vulputate ligula gravida ultrices a sollicitudin nulla. Proin fringilla cursus magna, at consectetur nulla vulputate nec. Fusce dolor turpis, lacinia id maximus et, condimentum nec massa. Donec quis porttitor lorem. Integer congue turpis sapien, eget tincidunt elit suscipit nec. Duis sed enim eu dui dapibus commodo vitae pharetra turpis. Maecenas rutrum tristique massa eu posuere. Aliquam facilisis velit nec ante pretium, consectetur dapibus elit laoreet. Aliquam erat volutpat.In ut ligula volutpat, consectetur turpis eget, volutpat nulla. Donec elit justo, cursus in elit vitae, faucibus volutpat diam. Integer ipsum metus, varius nec tristique vitae, scelerisque non risus. Maecenas ut urna libero. Praesent ut dictum est. Pellentesque rutrum placerat est, sed."},
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
                new Advertisement {AdvertisementId=Guid.NewGuid(),Active=true,DateAdded=DateTime.Now,Title="Seta i Ogórek 10 zł !!!",
                    Description ="W czwartki do godziny 21:00 seta wódki i ogórki za 10 zł dla studnetów", Tag="Promocja",GastronomicVenue = gastroVenuses.Where(x =>x.GastronomicVenueName.Equals("Setka Bar")).FirstOrDefault()},
                new Advertisement {AdvertisementId=Guid.NewGuid(),Active=true,DateAdded=DateTime.Now,Title="5 shotów w cenie 3",
                    Description ="W poniedziałki do godziny 19:00 5 shotów w cenie 3", Tag="Promocja",GastronomicVenue = gastroVenuses.Where(x =>x.GastronomicVenueName.Equals("Czupito")).FirstOrDefault()},
                new Advertisement {AdvertisementId=Guid.NewGuid(),Active=true,DateAdded=DateTime.Now,Title=" Wortki za Piątaka ",
                    Description ="W każdy Wtorek duże piwo tylko 5 zł", Tag="Promocja",GastronomicVenue = gastroVenuses.Where(x =>x.GastronomicVenueName.Equals("Remont Bar")).FirstOrDefault()},
                new Advertisement {AdvertisementId=Guid.NewGuid(),Active=true,DateAdded=DateTime.Now,Title="Środa z pizzą",
                    Description ="W Środy każda pizza 18 zł", Tag="Promocja",GastronomicVenue = gastroVenuses.Where(x =>x.GastronomicVenueName.Equals("Remont Bar")).FirstOrDefault()}

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
