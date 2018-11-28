using PubProjectApi.Models;
using PubProjectApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Repository
{
    public class LikeRepository: Repository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context) { }

    }
}
