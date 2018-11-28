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
        ILikeRepository _likeRepository;

        public AdvertisementService(IAdvertisementRepository advert, IGastronomicVenuesRepository gastronomicVenuesRepository, ILikeRepository likeRepository )
        {
            _advertRepository = advert;
            _gastronomicVenuesRepository = gastronomicVenuesRepository;
            _likeRepository = likeRepository;
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

        public async Task<IEnumerable<Advertisement>> GetByVenue(Guid id)
        {
            return (await _advertRepository.GetAll()).Where(x => x.GastronomicVenueId.Equals(id)).ToList();
        }

        public async Task<Advertisement> GetById(Guid id)
        {
            return (await _advertRepository.GetById(id));
        }

        public async Task<List<AdvertisementListView>> GetAdvertsList()
        {
            var adv = (await _advertRepository.GetAll());
            List<AdvertisementListView> advList = new List<AdvertisementListView>();
            foreach (var a in adv)
            {
                var likes = (await _likeRepository.GetAll()).Where(x => x.AdvertId.Equals(a.AdvertisementId));
                advList.Add(new AdvertisementListView { Advertisement = a, GastronomicVenue = (await _gastronomicVenuesRepository.GetById(a.GastronomicVenueId)), Likes=likes, CountLikes = likes.Count() });
            }
            return advList;
        }

        public void AddAdvert(Advertisement advertisement)
        {
            _advertRepository.Add(advertisement);
        }

        public void AddLike(Guid AdvertId)
        {

        }
    }
}
