using System;

namespace oms.model
{
    /// <summary>
    /// ConfigModel
    /// </summary>
    public class ConfigModel
    {

    }

    /// <summary>
    /// 运维配置参数
    /// </summary>
    public class OperationsConfig
    {
        /// <summary>
        /// 运维名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 执行周期
        /// </summary>
        public string PeriodSeconds { get; set; }
        /// <summary>
        /// git信息
        /// </summary>
        public GitInfoModel Git { get; set; }
        /// <summary>
        /// 在某时刻执行
        /// </summary>
        public string AtTime { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public int TimeoutSeconds { get; set; }
        /// <summary>
        /// 失败尝试次数
        /// </summary>
        public int FaildTryTimes { get; set; }
    }
}
