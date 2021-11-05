using AdventureWorksOBP.Data.Bases;
using AdventureWorksOBP.Data.Interfaces;
using AdventureWorksOBP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksOBP.Data.DataModels
{
    public class DataRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdventureWorksOBPContext context;

        public DataRepository(AdventureWorksOBPContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        
        public IQueryable<T> Read(Expression<Func<T, bool>> expression)
            => context.Set<T>().Where(expression);
        
        public async Task<T> ReadBySpec(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(context.Set<T>().AsNoTracking().AsQueryable(),
                (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));

            return await secondaryResult.Where(spec.Criteria).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ReadAllBySpec(ISpecification<T> spec, int skip, int count)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(context.Set<T>().AsNoTracking().AsQueryable().Skip(skip).Take(count),
                (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));

            return await secondaryResult.Where(spec.Criteria).ToListAsync();
        }


        public IQueryable<T> ReadAll(int skip, int count)
            => context.Set<T>().Skip(skip).Take(count); 

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
