﻿using Domain.Entities;
using Domain.RepositoriesInterfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly StorageContext Context;

        protected BaseRepository(StorageContext context)
        {
            Context = context;
        }

        public virtual T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>()
                .AsQueryable();
        }

        public virtual T Create(T newEntity)
        {
            return Context.Set<T>().Add(newEntity);
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var dbSet = Context.Set<T>();

            dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
