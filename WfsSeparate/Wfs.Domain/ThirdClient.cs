using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class ThirdClient : Entity,IHasRecordTime,IHasAuditOne
    {
        public string ThirdClientName { get; set; }
        public string ThirdClientCode { get; set; }
        public string ThirdClientSecret { get; set; }
        public string ThirdClientUrl { get; set; }
        public string ThirdDescription { get; set; }
        public int IsActive { get; set; }
        public DateTime? ExpireTime { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime? UpdationTime { get; set; }

        public Guid CreateOne { get; set; }

        public Guid? UpdateOne { get; set; }
    }
}
