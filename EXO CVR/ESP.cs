using ABI.CCK.Components;
using ABI_RC.Core.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EXO_CVR
{
    internal class ESP
    {
		private static void OnAvatarChanged(PuppetMaster __instance)
		{
			Main.s_yValue = __instance.gameObject.GetComponentInChildren<CVRAvatar>().viewPosition.y;
			bool flag = __instance.gameObject.name == "_PLAYERLOCAL";
			if (!flag)
			{
				bool flag2 = __instance.transform.Find("Esp") != null;
				if (flag2)
				{
					__instance.transform.Find("Esp").transform.localPosition = new Vector3(0f, Main.s_yValue / 1.6f, 0f);
					__instance.transform.Find("Esp").transform.localScale = new Vector3(Main.s_yValue / 1.6f, Main.s_yValue / 1.4f, Main.s_yValue / 1.5f);
				}
				else
				{
					__instance.gameObject.AddComponent<Outline>();
				}
			}
		}
	}
}
