using PubProjectApi.Models;
using PubProjectApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public class GastronomicVenuesService : IGastronomicVenuesService
    {
        IGastronomicVenuesRepository _gastronomicVenuesRepository;

        public GastronomicVenuesService (IGastronomicVenuesRepository gastronomicVenuesRepository)
        {
            _gastronomicVenuesRepository = gastronomicVenuesRepository;
        }
        public async Task<IEnumerable<GastronomicVenue>> GetAll()
        {
            return await _gastronomicVenuesRepository.GetAll();
        }

        public async Task<GastronomicVenue> GetById(Guid id)
        {
            return await _gastronomicVenuesRepository.GetById(id);
        }

        public void AddVenue(GastronomicVenue gastronomicVenue)
        {
            _gastronomicVenuesRepository.Add(gastronomicVenue);
        }

        public async Task<GastronomicVenue> GetByOwnerId(Guid id)
        {
            return (await _gastronomicVenuesRepository.GetAll()).Where(x => x.UserId.Equals(id)).FirstOrDefault();
        }
    }
}
