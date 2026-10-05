using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertGenerate
{
    public class GenericService<T> where T : class
    {
        protected readonly CertProjectDBEntities _context;
        protected readonly DbSet<T> _dbSet;

        public GenericService()
        {
            _context = new CertProjectDBEntities();
            _dbSet = _context.Set<T>();
        }

        // --------------------------------------------------
        // Synchronous Methods
        // --------------------------------------------------

        // 1. Get all records
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // 2. Get record using ID
        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        // 3. Add new record
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        // 4. Update record
        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        // 5. Delete record using ID
        public virtual void Delete(object id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            Save();
        }

        // 6. Save changes in DB
        public virtual void Save()
        {
            _context.SaveChanges();
        }

        // --------------------------------------------------
        // Asynchronous Methods (Async)
        // --------------------------------------------------

        // 7. Async Save
        public virtual async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // 8. Async GetAll
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // 9. Async GetById
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        // 10. Async Insert
        public virtual async Task<bool> InsertAsync(T entity)
        {
            _dbSet.Add(entity);
            return await SaveAsync();
        }

        // 11. Async Update
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await SaveAsync();
        }

        // 12. Async Delete
        public virtual async Task<bool> DeleteAsync(object id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                return await DeleteAsync(entity);
            }
            return false;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            return await SaveAsync();
        }


    }
}