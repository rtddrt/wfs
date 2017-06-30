using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Wfs.Application;
using Wfs.Core;
using Wfs.WebApi.Base;

namespace Wfs.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        #region Private Field
        private readonly AccountApplication _accountApplication;
        #endregion

        #region Ctor

        public AccountController()
        {
            _accountApplication = IocRegister.GetType<AccountApplication>();
        }

        #endregion
    }
}
