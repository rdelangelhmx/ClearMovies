using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Persistence.Entity
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
    {
        readonly IConfiguration config;

        private Dictionary<Type, object> _repositories;
        public TContext Context { get; }

        public UnitOfWork(TContext context, IConfiguration _config)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));

            config = _config;
        }

        public IEntityRepository<TEntity> EntityRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new EntityRepository<TEntity>(Context);
            return (IEntityRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public DataTable GetDataFromQuery(string Query, List<SqlParameter> parameters = null)
        {
            var dt = new DataTable();
            var dbConn = Context.Database.GetDbConnection();
            try
            {
                if (dbConn.State != ConnectionState.Open) dbConn.Open();
                using (var dbCommand = dbConn.CreateCommand())
                {
                    dbCommand.CommandText = Query;
                    if (parameters != null)
                    {
                        dbCommand.Parameters.Clear();
                        parameters.ForEach(f => {
                            var parameter = dbCommand.CreateParameter();
                            parameter.ParameterName = f.ParameterName;
                            parameter.Value = f.Value;
                            dbCommand.Parameters.Add(parameter);
                        });
                    }
                    using (var reader = dbCommand.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConn.State != ConnectionState.Closed) dbConn.Close();
            }
        }

        public bool GetDataFromSql(string Sql, object[] parameters = null)
        {
            var dbConn = Context.Database.GetDbConnection();
            try
            {
                if (dbConn.State != ConnectionState.Open) dbConn.Open();
                return Context.Database.ExecuteSqlRaw(Sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConn.State != ConnectionState.Closed) dbConn.Close();
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
