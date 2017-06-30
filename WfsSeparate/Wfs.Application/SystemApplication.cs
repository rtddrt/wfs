using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Application.SystemDto;
using Wfs.Core;
using Wfs.Domain;
using Wfs.Domain.IRepositories;
using Wfs.EntityFramework.Context;

namespace Wfs.Application
{
    public class SystemApplication:BaseApplication
    {
        #region private field

        private readonly IRepository<SysAction> _sysActionRepository;

        #endregion

        #region Ctor
        public SystemApplication(IDbContextScopeFactory dbContextScopeFactory, 
            IRepository<SysAction> sysActionRepository)
            : base(dbContextScopeFactory)
        {
            _sysActionRepository = sysActionRepository;
        }
        

        #endregion

        #region Init
        /// <summary>
        /// 初始化系统动作器
        /// </summary>
        public void InitSysAction(List<SysActionDto> list)
        {
            var entityList = list.MapToList<SysAction>().AsEnumerable();
            using (var db = _dbContextScopeFactory.Create())
            {
                if (_sysActionRepository.GetCount() == 0)
                {
                    _sysActionRepository.BatchAdd(entityList);
                }
                db.SaveChanges();
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 批量添加或者更新
        /// </summary>
        /// <param name="listAll"></param>
        public void AddOrUpdate(List<SysActionDto> listAll)
        {
            var mapList = listAll.MapToList<SysAction>();
            using (var db = _dbContextScopeFactory.Create())
            {
                var list = _sysActionRepository.Find().ToList();

                var exceptList = (from @new in mapList
                    from old in list
                    where @new.Id != old.Id
                    select @new).ToList();

                _sysActionRepository.BatchAdd(exceptList);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 更新SysAction
        /// </summary>
        /// <param name="model"></param>
        public void Update(SysActionDto model)
        {
            var map =new SysAction()
            {
                NamedDescription = model.NamedDescription,
                UpdateOne = model.UpdateOne,
                UpdationTime = model.UpdationTime,
                IsActive = model.IsActive
            };
            using (var db = _dbContextScopeFactory.Create())
            {
                _sysActionRepository.Update(x=>x.Id==model.Id,map);
                db.SaveChanges();
            }
        }


        #endregion
    }
}
