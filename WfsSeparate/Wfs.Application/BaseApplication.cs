using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;

namespace Wfs.Application
{
    public  class BaseApplication
    {
        #region MyRegion

        public readonly IDbContextScopeFactory _dbContextScopeFactory;


        #endregion

        #region MyRegion

        public BaseApplication(IDbContextScopeFactory dbContextScopeFactory)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
        }
        

        #endregion
    }
}
