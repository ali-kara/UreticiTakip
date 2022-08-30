using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;

namespace Business
{
	public class BaseManager<T, TContext> : IEntity<T>
        where T : class, new()
        where TContext : DbContext, new()
    {

        protected static TContext context;
        protected static object _lockSync = new object();
		protected List<T> list;

        public BaseManager()
        {
            CreateContext();
        }

        private void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new TContext();
                    }
                }
            }
        }

        public int Delete(T entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            return context.SaveChanges();
        }

		public T Get(Expression<Func<T, bool>> filter = null)
        {
            return context.Set<T>().SingleOrDefault(filter);
        }

        public IEnumerable<T> GetIEnum(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                    ? context.Set<T>()
                    : context.Set<T>().Where(filter);
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
        }

        public int Insert(T entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
			
            updatedEntity.State = EntityState.Modified;
            return context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }

    public class BaseManager
    {
        public SqlDataReader reader { get; set; }
        public SqlConnection connection { get; set; }

    }
}

