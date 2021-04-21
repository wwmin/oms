using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using oms.model;
using oms.service;

namespace oms_server.Controllers
{
    /// <summary>
    /// 运维平台api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OmsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OmsController> _logger;
        private readonly List<OperationsConfig> _operationsConfig;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="operationsConfig"></param>
        public OmsController(ILogger<OmsController> logger, IOptions<List<OperationsConfig>> operationsConfig)
        {
            _logger = logger;
            _operationsConfig = operationsConfig.Value;
        }
        /*
         * 特定exe执行参数参考
            {
              "workingDirectory": "D:\\",
              "appFileName": "C:\\Program Files\\Microsoft SQL Server\\120\\Tools\\Binn\\OSQL.EXE",
              "arguments": "-S localhost -U sa -P Aa123456",
              "commands": [
                 "use Eletcric_2",
                 "go",
                 "select device_id from device_inverter",
                 "go",
                 "QUIT"
              ]
            }
         */
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="runCmdService"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RunCmd([FromServices] IRunCmdService runCmdService, [FromBody] CommandInput input)
        {

            var res = runCmdService.RunCmd(input);
            return Ok(res);
        }
    }
}
