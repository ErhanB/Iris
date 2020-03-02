using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iris.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity Get(int id);
        public void Insert(TEntity entity);
        // public void Update(TEntity dbEntity, TEntity entity);
        public void Update(TEntity entity);

        public void Delete(TEntity entity);

        public void Save();
    }
}
