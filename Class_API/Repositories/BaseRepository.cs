
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Class_API.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Class_API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly Classdb _context;
        public BaseRepository(Classdb context)
        {
            _context = context;
        }

        //Get
        public async Task<T> Get(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        //Get All
        public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }


        //Add
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //Update
        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        //Delete
        public async Task<T> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;

        }



    }
 }

