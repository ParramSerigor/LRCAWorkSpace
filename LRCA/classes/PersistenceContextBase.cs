using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace LRCA.classes
{
	public abstract class PersistenceContextBase: DbContext, IPersistenceContext
	{
		#region Constructor
		protected PersistenceContextBase()
			: base()
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}
		protected PersistenceContextBase(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
			_connectionString = nameOrConnectionString;
		}
		#endregion

		#region OnModelCreating
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var configurations = modelBuilder.Configurations;
			var nullTypes = Assembly
				.GetAssembly(typeof(DomainObject))
				.ExportedTypes
				.Where(each => each.Name.StartsWith("Null", StringComparison.Ordinal));
			modelBuilder.Ignore(nullTypes);
			
		}
		#endregion

		#region Insert
		protected virtual TEntity Insert<TEntity>(TEntity entity) where TEntity : class
		{
			var entityType = entity.GetType();
			var baseType = entityType.BaseType;
			var domainObject = entity as DomainObject;
			
			return Set<TEntity>().Add(entity);
		}
		#endregion

		#region Update
		protected virtual TEntity Update<TEntity>(TEntity entity) where TEntity : class
		{
			var obj = entity as DomainObject;
			if (!ReferenceEquals(null, obj))
			{
				obj.SetModified();
			}
			Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion

		#region FindAsync
		protected virtual async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class
		{
			return await Set<TEntity>().FindAsync(id);
		}
		#endregion

		#region Delete
		protected virtual TEntity Delete<TEntity>(TEntity entity, bool force = false) where TEntity : class
		{
			var obj = entity as DomainObject;
			if (!ReferenceEquals(null, obj) && !force)
			{
				obj.SetModified();
				Entry(entity).State = EntityState.Modified;
			}
			else
			{
				Set<TEntity>().Remove(entity);
			}
			return entity;
		}
		#endregion

		#region IPersistenceContext Members
		TEntity IPersistenceContext.Insert<TEntity>(TEntity entity)
		{
			return Insert(entity);
		}
		TEntity IPersistenceContext.Update<TEntity>(TEntity entity)
		{
			return Update(entity);
		}
		async Task<TEntity> IPersistenceContext.FindAsync<TEntity>(int id)
		{
			return await FindAsync<TEntity>(id);
		}
		TEntity IPersistenceContext.Delete<TEntity>(TEntity entity, bool force)
		{
			return Delete(entity, force);
		}
		int IPersistenceContext.SaveChanges()
		{
			return SaveChanges();
		}
		#endregion

		#region Fields
		private readonly string _connectionString;
		private static readonly DbProviderFactory _dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
		#endregion
	}
}