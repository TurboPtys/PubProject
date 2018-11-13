using Microsoft.EntityFrameworkCore;
using PubProjectApi.Models;
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

        public AdvertisementService(IAdvertisementRepository advert)
        {
            _advertRepository = advert;
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
    }
}
