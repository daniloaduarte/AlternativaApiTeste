using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDanilo.Data.Context;
using WebApiDanilo.Domain.Interfaces;
using WebApiDanilo.Domain.Models;

namespace WebApiDanilo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MyContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        
        public async virtual Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async virtual Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async virtual Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async virtual Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async virtual Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
