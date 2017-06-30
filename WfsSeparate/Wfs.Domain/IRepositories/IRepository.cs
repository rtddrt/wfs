using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wfs.Core;

namespace Wfs.Domain.IRepositories
{
    public interface IRepository<T> : IDependency where T : Wfs.Domain.Base.Entity
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        T FindSingle(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 异步查找
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Task<T> FindSingleAsync(Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> exp);

        /// <summary>
        /// 异步检查是否存在
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Task<bool> IsExistAsync(Expression<Func<T,bool>> exp);
        /// <summary>
        /// 按条件查找
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 汇总数量
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        void BatchAdd(IEnumerable<T> entities);

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 按指定的ID进行批量更新
        /// </summary>
        void Update(Expression<Func<T, object>> identityExp, T entity);

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);
        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete(Expression<Func<T, bool>> exp);

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageindex">The pageindex.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="orderby">排序，格式如："Id"/"Id descending"</param>
        IQueryable<T> Find(int pageindex, int pagesize, out int count, string orderby = "",
            Expression<Func<T, bool>> exp = null);
    }
}
