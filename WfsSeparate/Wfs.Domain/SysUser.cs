using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysUser:Entity,IHasRecordTime,ILogicalRemove
    {
        public string SysUserName { get; set; }

        public string SysUserPwd { get; set; }

        public string SysUserRandomCode { get; set; }
        public int IsActive { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime? UpdationTime { get; set; }

        public int IsDelete { get; set; }
    }
}
