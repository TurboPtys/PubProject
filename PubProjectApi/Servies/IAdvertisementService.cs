using PubProjectApi.Models;
using PubProjectApi.Models.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<Advertisement>> GetAll();
        Task<IEnumerable<Advertisement>> GetByTag(string tag);
        Task<List<AdvertisementListView>> GetAdvertsList();
    }
}
