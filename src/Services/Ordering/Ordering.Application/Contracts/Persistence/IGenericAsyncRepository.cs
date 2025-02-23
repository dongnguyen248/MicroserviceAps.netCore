﻿using Ordering.Domain.Common;
using System.Linq.Expressions;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IGenericAsyncRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>
                                                                                                       orderby = null,
                                                                                                       string includeString = null,
                                                                                                       bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>> predicat = null,
                                                                 Func<IQueryable<T>,IOrderedQueryable<T>> orderby = null,
                                                                 List<Expression<Func<T,object>>> include = null,
                                                                 bool disableTracking = true);
        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
