using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oms.model
{
    /// <summary>
    /// ResultModel
    /// </summary>
    public class Result<T>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public Result(ResultCodeEnum code = ResultCodeEnum.Success, bool success = true, string message = null, T data = default)
        {
            Code = code;
            Success = success;
            Message = message;
            Data = data;
        }
        /// <summary>
        /// 正确或错误代码
        /// </summary>
        public ResultCodeEnum Code { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 正确或错误信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 正确数据
        /// </summary>
        /// <returns></returns>
        public static Result<T> Ok(T data)
        {
            return new Result<T>(code: ResultCodeEnum.Success, success: true, message: "", data: data);
        }
        /// <summary>
        /// 错误数据
        /// </summary>
        /// <returns></returns>
        public static Result<T> Bad(string message)
        {
            return new Result<T>(code: ResultCodeEnum.Fail, success: false, message: message, data: default);
        }

    }
}
