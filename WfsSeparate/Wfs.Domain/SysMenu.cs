using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysMenu : Entity
    {
        public string Icon { get; set; }
        public string MenuName { get; set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string MenuUrl { get; set; }

        public Guid? MenuPId { get; set; }

        public int? Order { get; set; }

        public string Description { get; set; }

        public int IsActive { get; set; }

    }
}
