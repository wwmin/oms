using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oms.model
{
    /// <summary>
    /// 字符编码Enum
    /// </summary>
    public enum EncodingEnum
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 1,
        /// <summary>
        /// UTF8
        /// </summary>
        UTF8 = 2,
        /// <summary>
        /// Unicode
        /// </summary>
        Unicode = 3,
        /// <summary>
        /// ASCII
        /// </summary>
        ASCII = 4
    }

    /// <summary>
    /// Encoding 帮助类
    /// </summary>
    public static class EncodingCommon
    {
        /// <summary>
        /// 根据id获取Encoding
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Encoding GetByValue(int value)
        {
            return value switch
            {
                (int)EncodingEnum.Default => Encoding.Default,
                (int)EncodingEnum.UTF8 => Encoding.UTF8,
                (int)EncodingEnum.Unicode => Encoding.Unicode,
                (int)EncodingEnum.ASCII => Encoding.ASCII,
                _ => null
            };
        }

        /// <summary>
        /// 根据id获取Encoding
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Encoding GetByName(string value)
        {
            value = value.ToLower();
            return value switch
            {
                "default" => Encoding.Default,
                "utf8" => Encoding.UTF8,
                "unicode" => Encoding.Unicode,
                "ascii" => Encoding.ASCII,
                _ => null
            };
        }

    }
}
