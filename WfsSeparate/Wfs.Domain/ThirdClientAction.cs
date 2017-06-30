using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class ThirdClientAction : Entity
    {
        public string ActionId { get; set; }

        public Guid ThirdClientId { get; set; }
    }
}
