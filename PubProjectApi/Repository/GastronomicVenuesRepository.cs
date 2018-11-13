using PubProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Repository.Interface
{
    public class GastronomicVenuesRepository: Repository<GastronomicVenue>, IGastronomicVenuesRepository
    {
        public GastronomicVenuesRepository(ApplicationDbContext context): base(context) { }
    }
}
