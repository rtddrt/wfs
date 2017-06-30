using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class ApiActionUsingLog : Entity,IHasRecordTime
    {
        public Guid ActionId { get; set; }

        public string Ip { get; set; }

        public string BrowserInfo { get; set; }

        public string UsingResult { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime? UpdationTime { get; set; }
    }
}
