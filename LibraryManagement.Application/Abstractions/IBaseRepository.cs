﻿using System.Linq.Expressions;

namespace LibraryManagement.Application.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(Expression<Func<T, bool>> expression);
        public Task<T> GetByAny(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAll();
        
    }
}
