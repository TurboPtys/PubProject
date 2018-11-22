using Microsoft.EntityFrameworkCore;
using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using PubProjectApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public class AdvertisementService : IAdvertisementService
    {
        IAdvertisementRepository _advertRepository;
        IGastronomicVenuesRepository _gastronomicVenuesRepository;

        public AdvertisementService(IAdvertisementRepository advert, IGastronomicVenuesRepository gastronomicVenuesRepository)
        {
            _advertRepository = advert;
            _gastronomicVenuesRepository = gastronomicVenuesRepository;
        }

        public async Task<IEnumerable<Advertisement>> GetAll()
        {
            //return await _advertisementRepository.GetAll();
            return await _advertRepository.GetAll();
        }

        public async Task<IEnumerable<Advertisement>> GetByTag(string tag)
        {
            
            return (await _advertRepository.GetAll()).Where(x => x.Tag.Equals(tag)).ToList();
        }

        public async Task<List<AdvertisementListView>> GetAdvertsList()
        {
            var adv = (await _advertRepository.GetAll());
            List<AdvertisementListView> advList = new List<AdvertisementListView>();
            foreach (var a in adv)
            {
                advList.Add(new AdvertisementListView { Advertisement = a, GastronomicVenue = (await _gastronomicVenuesRepository.GetById(a.GastronomicVenueId)) });
            }
            return advList;
        }

        public void AddAdvert(Advertisement advertisement)
        {
            _advertRepository.Add(advertisement);
        }
    }
}
