using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PubProjectApi.Models;

namespace PubProjectApi.Servies
{
    public interface IGastronomicVenuesService
    {
        Task<IEnumerable<GastronomicVenue>> GetAll();
    }
}
