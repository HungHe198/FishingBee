using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Repositories
{
    public interface IAllRepositories<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public IQueryable<T> GetAllQueryable();
        public Task<T> GetById(Guid id);
        public Task<T> Create(T Obj);
        public Task Update(Guid id, T Obj);
        public Task Delete(Guid id);
        public Task<bool> EntityExists(Guid id);

        //private bool CategoryExists(Guid id)
        //{
        //  return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

    }
}
