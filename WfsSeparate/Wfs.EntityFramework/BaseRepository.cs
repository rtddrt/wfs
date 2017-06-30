using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using EntityFramework.Extensions;
using Wfs.Core;
using Wfs.Domain.IRepositories;
using Wfs.EntityFramework.Context;

namespace Wfs.EntityFramework
{
    public class BaseRepository<T> : IRepository<T> where T : Wfs.Domain.Base.Entity
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        public BaseRepository(IAmbientDbContextLocator locator)
        {
            _ambientDbContextLocator = locator;
        }

        private WfsContext Context
        {
            get { return _ambientDbContextLocator.Get<WfsContext>(); }
        }

        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {

            return Context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> exp = null)
        {
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(exp);
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> exp)
        {
            return await Context.Set<T>().AnyAsync(exp);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }
        public int GetCount(System.Linq.Expressions.Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void BatchAdd(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            //通过主键进行匹配
            var entry = Context.Entry(entity);
            //todo:如果状态没有任何更改，会报错
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(Expression<Func<T, object>> identityExp, T entity)
        {
            Context.Set<T>().AddOrUpdate(identityExp, entity);
        }

        public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            Context.Set<T>().Where(where).Update(entity);
        }
        public void Delete(Expression<Func<T, bool>> exp)
        {
            Context.Set<T>().Where(exp).Delete();
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageindex">The pageindex.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="orderby">排序，格式如："Id"/"Id descending"</param>
        public IQueryable<T> Find(int pageindex, int pagesize, out int count, string orderby = "", Expression<Func<T, bool>> exp = null)
        {
            if (pageindex < 1) pageindex = 1;
            if (string.IsNullOrEmpty(orderby))
                orderby = "Id descending";
            count = GetCount(exp);
            return Filter(exp).OrderBy(orderby).Skip(pagesize * (pageindex - 1)).Take(pagesize);
        }


        #region Private Filed
        private IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = Context.Set<T>().AsNoTracking().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }
        #endregion

        //todo 新增的公共方法，放于此处
        #region 扩展方法

        public List<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            return ((IObjectContextAdapter)Context).ObjectContext.ExecuteStoreQuery<TElement>(commandText, parameters).ToList();
        }
        #endregion
    }
}
