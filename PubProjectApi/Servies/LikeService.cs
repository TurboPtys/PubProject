using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView.Advert;
using PubProjectApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public class LikeService: ILikeService
    {
        ILikeRepository _likeRepository;
        IAdvertisementRepository _advertisementRepository;

        public LikeService(ILikeRepository likeRepository, IAdvertisementRepository advertisementRepository)
        {
            _likeRepository = likeRepository;
            _advertisementRepository =  advertisementRepository;
        }

        public void AddLike(AddLike addLike)
        {
            Like like = new Like { Id = new Guid(), UserId = addLike.UserId, AdvertId = addLike.AdvertId };
            _likeRepository.Add(like);
            var adv = _advertisementRepository.GetById(addLike.AdvertId).Result;
            adv.CountLike = adv.CountLike + 1;
            _advertisementRepository.Edit(adv);
        }

        public async Task<IEnumerable<Like>> GetLikeByAdvert(Guid AdvertId)
        {
            var Likes = (await _likeRepository.GetAll()).Where(x => x.AdvertId.Equals(AdvertId));
            return Likes;
        }
    }
}
