using System;
using System.Collections;
using System.Runtime.InteropServices;
using MelonLoader;
using UnityEngine;

namespace EXO_CVR.WindowName
{
	public class WindowName
	{
		[DllImport("user32.dll")]
		public static extern bool SetWindowText(IntPtr hwnd, string lpString);
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string className, string windowName);
		internal static IEnumerator ChangeTitle()
		{
			ChilloutVR = FindWindow(null, "ChilloutVR");
			MelonLogger.Msg("Found CVR: " + ChilloutVR.ToString());
			for (; ; )
			{
				SetWindowText(ChilloutVR, "[");
				Console.Title = "[";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E");
				Console.Title = "[ E";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E X");
				Console.Title = "[ E X";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E X O");
				Console.Title = "[ E X O";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E X O ]");
				Console.Title = "[ E X O ]";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E X O ]");
				Console.Title = "[ E X O ]";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E X O");
				Console.Title = "[ E X O";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E X");
				Console.Title = "[ E X";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ E");
				Console.Title = "[ E";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[");
				Console.Title = "[";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "");
				Console.Title = "";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "[ C V R ]");
				Console.Title = "[ C V R ]";
				yield return new WaitForSecondsRealtime(0.5f);
				SetWindowText(ChilloutVR, "");
				Console.Title = "";
				yield return new WaitForSecondsRealtime(0.5f);
			}
		}
		private static IntPtr ChilloutVR = IntPtr.Zero;
	}
}
