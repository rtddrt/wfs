using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Domain.Base
{
    public interface IHasRecordTime
    {
        DateTime CreationTime { get; set; }

        DateTime? UpdationTime { get; set; }
    }
}
