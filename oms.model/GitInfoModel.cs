using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oms.model
{
    /// <summary>
    /// GitInfo
    /// </summary>
    public class GitInfoModel
    {
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string RepositoryUrl { get; set; }
        /// <summary>
        /// 仓库分支
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
    }
}
