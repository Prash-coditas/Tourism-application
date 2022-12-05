using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_1.Services
{
    public interface IDbAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        bool Delete(TPk id);
    }
    
}
