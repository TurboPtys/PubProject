using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView.Advert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public interface ILikeService
    {
        void AddLike(AddLike addLike);
        Task<IEnumerable<Like>> GetLikeByAdvert(Guid AdvertId);
    }
}
