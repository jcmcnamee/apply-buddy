﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Contracts.Persistence;
public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync<TId>(TId id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
