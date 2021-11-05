using AdventureWorksOBP.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksOBP.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        IQueryable<T> ReadAll(int skip, int count);
        IQueryable<T> Read(Expression<Func<T, bool>> expression);
        Task<T> ReadBySpec(ISpecification<T> spec);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
