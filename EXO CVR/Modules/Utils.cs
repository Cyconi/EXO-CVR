using ABI_RC.Core.Player;
using ABI_RC.Core.Util;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EXO_CVR.Modules
{
	internal class Utils
	{
		//patcahed
		internal static void FDrop()
		{
			if (PlayerSetup.Instance != null && Main.FloorDropToggle)
			{
				CVRSyncHelper.SpawnPortal("i+419d1525b0ca1683-921003-133d82-16d0b31a", float.NaN, float.NaN, float.NaN);
				MelonLogger.Msg("Floor Drop Activated!, You Will Now Need To Reset Your Game");
			}						
		}
	}
}
