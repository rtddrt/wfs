using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Application.LogDto;
using Wfs.Core;
using Wfs.Domain;
using Wfs.Domain.IRepositories;

namespace Wfs.Application
{
    public class LogApplication:BaseApplication
    {
        #region private field
        private readonly IRepository<ApiActionUsingLog> _apiActionLogRepository;
        

        #endregion
        public LogApplication(IRepository<ApiActionUsingLog> apiActionLogRepository,IDbContextScopeFactory dbContextScopeFactory) :
            base(dbContextScopeFactory)
        {
            _apiActionLogRepository = apiActionLogRepository;
        }

        #region method

        public void AddApiUsingLogs(UsingApiLogDto model)
        {
            var entity = model.MapTo<ApiActionUsingLog>();
            using (var db = _dbContextScopeFactory.Create())
            {
                entity.Id=Guid.NewGuid();
                _apiActionLogRepository.Add(entity);
                db.SaveChanges();
            }
        }
        

        #endregion
    }
}
