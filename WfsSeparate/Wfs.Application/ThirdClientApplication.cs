using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Domain;
using Wfs.Domain.IRepositories;

namespace Wfs.Application
{
   public class ThirdClientApplication:BaseApplication
   {
       #region private field
       private readonly IRepository<ThirdClient> _thirdClientRepository;
       

       #endregion

       #region Ctor
       public ThirdClientApplication(IDbContextScopeFactory dbContextScopeFactory, IRepository<ThirdClient> thirdClientRepository)
           : base(dbContextScopeFactory)
       {
           _thirdClientRepository = thirdClientRepository;
       }
       

       #endregion

       #region source
       /// <summary>
       /// 校验第三方密钥
       /// </summary>
       /// <param name="clientId"></param>
       /// <param name="key"></param>
       /// <returns></returns>
       public bool CheckClientId(string clientId, string key)
       {
           using (var db=_dbContextScopeFactory.CreateReadOnly())
           {
              var result=  _thirdClientRepository.IsExist(
                   x => x.ThirdClientCode == clientId && x.ThirdClientSecret == key && x.IsActive == 1);
               return result;
           }
       }
       

       #endregion
   }
}
