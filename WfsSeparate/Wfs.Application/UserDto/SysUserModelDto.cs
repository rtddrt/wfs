using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Application.UserDto
{
    public class SysUserModelDto
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string SysUserName { get; set; }

        /// <summary>
        /// 角色主键数组
        /// </summary>
        public List<Guid> RoleIdArray { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan? ExpireTime { get; set; }
    }
}
