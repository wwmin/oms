using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using oms.model;

namespace oms.service
{
    public class RunCmdService : IRunCmdService
    {
        public RunCmdService()
        {

        }

        public List<string> RunCmd(CommandInput input)
        {
            try
            {
                string workingDirectory = input.WorkingDirectory;
                List<string> commandLines = input.Commands;
                ProcessStartInfo psi = new ProcessStartInfo(CONST.WindowsCmdPath);

                psi.Arguments = input.Arguments;//启动命令时的参数
                psi.FileName = input.AppFileName ?? null;//如果时cmd原生命令此出可留空
                psi.WorkingDirectory = workingDirectory;
                //psi.Verb = "RunAs";
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardError = true;
                if (input.StandardOutputEncoding != null)
                {
                    psi.StandardOutputEncoding = EncodingCommon.GetByName(input.StandardOutputEncoding);
                }
                if (input.StandardErrorEncoding != null)
                {
                    psi.StandardErrorEncoding = EncodingCommon.GetByName(input.StandardErrorEncoding);
                }
                if (input.StandardInputEncoding != null)
                {
                    psi.StandardInputEncoding = EncodingCommon.GetByName(input.StandardInputEncoding);
                }
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process process = Process.Start(psi);
                List<string> lines = new List<string>();
                StreamReader reader = process.StandardOutput;
                for (int i = 0; i < commandLines.Count; i++)
                {
                    process.StandardInput.WriteLine(commandLines[i]);
                }

                process.StandardInput.WriteLine("exit");


                process.WaitForExit();
                //在结束之后进行收集数据,防止一些工具不直接退出导致无法读取进程卡死现象
                while (!reader.EndOfStream)
                {
                    var msg = reader.ReadLine();
                    if (!string.IsNullOrEmpty(msg)) lines.Add(msg);
                }
                reader.Close();
                var errorMsg = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    lines.Add("errorMsg:" + errorMsg);
                }
                process.Close();
                process.Dispose();
                return lines;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
