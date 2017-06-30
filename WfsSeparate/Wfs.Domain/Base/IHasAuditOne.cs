using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Domain.Base
{
    public interface IHasAuditOne
    {
         Guid CreateOne { get; set; }

         Guid? UpdateOne { get; set; }
    }
}
