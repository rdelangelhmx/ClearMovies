using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository<TEntity> EntityRepository<TEntity>() where TEntity : class;
        int SaveChanges();
        DataTable GetDataFromQuery(string Query, List<SqlParameter> parameters = null);
        bool GetDataFromSql(string Sql, object[] parameters = null);
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
