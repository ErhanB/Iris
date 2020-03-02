using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Iris.Models.Repository
{
    public class GRepository<TEntity> : IDataRepository<TEntity> where TEntity: class
    {
        private Context _context;
        private DbSet<TEntity> table = null;

        public GRepository(Context context)
        {
            this._context = context;
            DbSet<TEntity> table = _context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            
            table.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            TEntity record = table.Find(entity);
            if(!(record is null))
            table.Remove(record);
        }

        public TEntity Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return table.ToList();
        }

        public void Update(TEntity entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
