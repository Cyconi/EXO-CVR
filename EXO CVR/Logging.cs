using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_RC.Core.Savior;
using ABI_RC.Core.Networking.IO.Instancing;

namespace EXO_CVR
{
    internal class Logging
    {
        public static void WorldLog()
        {
            var Instance = InstanceDetails_t.InstanceDetailsPool.GetObject();
            MelonLogger.Msg($"[ Instance ID - {Instance.InstanceId} ]");
            MelonLogger.Msg($"[ Instance Name - {Instance.InstanceName} ]");
            MelonLogger.Msg($"[ Instance Region - {Instance.Region} ]");
            MelonLogger.Msg($"[ Currant Players - {Instance.CurrentPlayer}/{Instance.MaxPlayer} ]");
        }
    }
}
