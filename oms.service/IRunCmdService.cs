using System.Collections.Generic;
using oms.model;

namespace oms.service
{
    public interface IRunCmdService
    {
        List<string> RunCmd(CommandInput input);
    }
}