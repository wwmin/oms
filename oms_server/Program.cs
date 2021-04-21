using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace oms_server
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {

        public delegate Int32 CallBack(ref long e);

        static CallBack mycall;

        [DllImport("kernel32")]
        private static extern Int32 SetUnhandledExceptionFilter(CallBack cb);

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //mycall = new CallBack(MyExceptionfilter);
            SetUnhandledExceptionFilter(mycall);
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



    }

}
