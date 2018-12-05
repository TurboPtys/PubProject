using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public interface IRepository<T> where T:class
    {
        Task<T> GetById(Guid? id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }

}
