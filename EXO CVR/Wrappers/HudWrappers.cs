using ABI_RC.Core.InteractionSystem;
using ABI_RC.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXO_CVR.Wrappers
{
    internal class HudWrappers
    {
        public static void TriggerAlert(string Title, string Content)
        {
            ViewManager.Instance.TriggerAlert(Title, Content, 1, true);
        }

        public static void TriggerPushAlter(string content)
        {
            ViewManager.Instance.TriggerPushNotification(content, 5);
        }

        public static void TriggerDropText(string Title, string content)
        {
            CohtmlHud.Instance.ViewDropText(Title, content);
        }
    }
}
