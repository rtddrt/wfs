using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Application.LogDto
{
    public class UsingApiLogDto
    {
        public Guid ActionId { get; set; }

        public string Ip { get; set; }


        public string BrowserInfo { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? UpdationTime { get; set; }

        public string UsingResult { get; set; }
    }
}
