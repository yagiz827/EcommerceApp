
using Core.Entities;
using Core.Uti.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, Ient, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T,bool>>filter);
        void Add(T Entity);
        void Update(T Entity, string name);
        void Delete(T Entity);

    }
}
