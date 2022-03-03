using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalsResto.Data;

namespace SalsResto.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SalsApplicationDbContext _RepoSalsApplicationDbContext;

        public RepositoryBase(SalsApplicationDbContext RepoSalsApplicationDbContext )
        {
            _RepoSalsApplicationDbContext = RepoSalsApplicationDbContext;
        }
        public void Create(T entity) => _RepoSalsApplicationDbContext.Set<T>().Add(entity);

        public void Delete(T entity) => _RepoSalsApplicationDbContext.Set<T>().Remove(entity);

        public void Update(T entity) => _RepoSalsApplicationDbContext.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges
                ? _RepoSalsApplicationDbContext.Set<T>().AsNoTracking()
                : _RepoSalsApplicationDbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges
                ? _RepoSalsApplicationDbContext.Set<T>().Where(expression).AsNoTracking()
                : _RepoSalsApplicationDbContext.Set<T>().Where(expression);
        }

      
    }
}
