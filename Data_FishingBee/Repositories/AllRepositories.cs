using Data_FishingBee.ContextFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Repositories
{
    public class AllRepositories<H> : IAllRepositories<H> where H : class
    {
		private readonly FishingBeeDbContext _db;
		private readonly DbSet<H> _dbSet;

		public AllRepositories(FishingBeeDbContext db)
		{
			_db = db;
			_dbSet = db.Set<H>(); // ✅ Lấy DbSet từ DbContext
		}
		public async Task<H> Create(H Obj)
        {
            try
            {
                _dbSet.Add(Obj);
                await _db.SaveChangesAsync();
                return Obj;
            }
            catch
            {
                return null;
            }
        }

        public async Task Delete(Guid id)
        {
            var delObj = await GetById(id);
            if (delObj != null)
            {
                _dbSet.Remove(delObj);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<H>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<H> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Update(Guid id, H Obj)
        {
            var updateObj = await GetById(id);
            if (updateObj != null)
            {
                _dbSet.Update(Obj);
                await _db.SaveChangesAsync();
            }
        }
    }
}
