using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Persistence.Entity
{
    internal class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        readonly DbContext dbContext;
        readonly DbSet<TEntity> dbSet;

        public EntityRepository(DbContext _context)
        {
            dbContext = _context;
            dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(string sql, params object[] parameters) => dbSet.FromSqlRaw(sql, parameters);

        public bool ExecQuery(string sql, params object[] parameters) => dbContext.Database.ExecuteSqlRaw(sql, parameters) > 0;

        public TEntity Find(params object[] keyValues) => dbSet.Find(keyValues);

        public bool Any(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return query.Any();
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null ? orderBy(query) : query;
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 20, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null ? orderBy(query).ToPaginate(index, size) : query.ToPaginate(index, size);
        }

        public IPaginate<TResult> GetList<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 20, bool disableTracking = true) where TResult : class
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? orderBy(query).Select(selector).ToPaginate(index, size)
                : query.Select(selector).ToPaginate(index, size);
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Add(params TEntity[] entities)
        {
            dbSet.AddRange(entities);
        }

        public void Upd(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void Upd(params TEntity[] entities)
        {
            dbSet.UpdateRange(entities);
        }

        public void Upd(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }

        public void Del(object id)
        {
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = dbSet.Find(id);
                if (entity != null) Del(entity);
            }
        }

        public void Del(TEntity entity)
        {
            var existing = dbSet.Find(entity);
            if (existing != null) dbSet.Remove(existing);
        }

        public void Del(params TEntity[] entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Del(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Del(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);
            else throw new DeleteFailureException(typeof(TEntity).Name, predicate, "The predicate of the sentence cannot be null");

            dbSet.RemoveRange(query);
        }

    }
}
