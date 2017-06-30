using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysAction : Entity, IHasRecordTime, IHasAuditOne
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Description { get; set; }

        public string NamedDescription { get; set; }

        public int IsActive { get; set; }

        public DateTime CreationTime { get; set; }


        public DateTime? UpdationTime { get; set; }


        public Guid CreateOne { get; set; }


        public Guid? UpdateOne { get; set; }

    }
}
