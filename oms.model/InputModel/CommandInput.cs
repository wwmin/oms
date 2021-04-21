using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oms.model
{
    /// <summary>
    /// 命令行
    /// </summary>
    public class CommandInput
    {
        /// <summary>
        /// 命令行工作目录
        /// </summary>
        public string WorkingDirectory { get; set; }
        /// <summary>
        /// 可直接执行的文件
        /// <para>如果时cmd原生命令则可为空</para>
        /// <para>如果是ftp.exe osql.exe等的执行完命令不及时退出的命令行工具,则需要指定该路径,且是直接启动</para>
        /// </summary>
        public string AppFileName { get; set; }
        /// <summary>
        /// 打开命令时的参数
        /// </summary>
        public string Arguments { get; set; }
        /// <summary>
        /// 输出Encoding
        /// </summary>
        public string StandardOutputEncoding { get; set; }
        /// <summary>
        /// 错误输出Encoding
        /// </summary>
        public string StandardErrorEncoding { get; set; }
        /// <summary>
        /// 输入Encoding
        /// <para>输入不能用UTF8, cmd不支持</para>
        /// </summary>
        public string StandardInputEncoding { get; set; }
        /// <summary>
        /// 待执行的命令
        /// </summary>
        public List<string> Commands { get; set; }
    }
}
