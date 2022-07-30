using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using HarmonyLib;
using System.Reflection;
using UnityEngine.XR;
using System.Runtime.InteropServices;

namespace EXO_CVR
{
    internal static class Misc
    {
        public static IEnumerator DelayAction(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action();
            yield break;
        }
        internal static float NextFloat(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
        public static void Start(this IEnumerator e) => MelonCoroutines.Start(e);
    }
    internal static class GetOrAdd
    {
        public static T GetOrAddComponents<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
                return gameObject.AddComponent<T>();

            return component;
        }
    }
    public class Load
    {
        internal static int i = 1;
        private static HarmonyMethod GetLocalPatch(string methodName) =>
            new HarmonyMethod(typeof(Load).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static));

        private delegate IntPtr onevent(IntPtr _instance, IntPtr eventData, IntPtr _nativeMethodInfoPtr);

        public static HarmonyLib.Harmony instance;
                      
        public static string USpeakTarget = "";
        public static int E7Target = -12;
        public static string Event9Target = "";
        public static string EmojiCopy = "";
              

       
        public static byte[] VectorToBytes(float x, float y, float z)
        {
            byte[] buffer = new byte[12];
            Buffer.BlockCopy(BitConverter.GetBytes(x), 0, buffer, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(y), 0, buffer, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(z), 0, buffer, 8, 4);
            return buffer;
        }                

        public static GameObject ControllerLeft, ControllerRight;
        public static GameObject Base;
        public static GameObject Tele;
        public static bool ClickTP = false;
        public static bool DragTP = false;

        internal static void AssignBindings()
        {
            if (Environment.CurrentDirectory.Contains("vrchat-vrchat"))
            {
                ControllerRight = GameObject.Find("/_Application/TrackingVolume/TrackingOculus(Clone)/OVRCameraRig/TrackingSpace/RightHandAnchor/PointerOrigin (1)");
                ControllerLeft = GameObject.Find("/_Application/TrackingVolume/TrackingOculus(Clone)/OVRCameraRig/TrackingSpace/LeftHandAnchor/PointerOrigin (1)");
            }
            else
            {
                ControllerRight = GameObject.Find("/_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (right)/PointerOrigin");
                ControllerLeft = GameObject.Find("/_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Controller (left)/PointerOrigin");
            }
            Base = new GameObject("Bot Shiz");
            Base.transform.SetParent(ControllerRight.transform);
            var Line = Base.AddComponent<LineRenderer>();
            Line.startWidth = 0.001f;
            Line.alignment = 0;
            Line.material = new Material(Shader.Find("GUI/Text Shader"));
            Line.enabled = false;
            Tele = new GameObject("TeleportObj");
            Tele.transform.SetParent(ControllerRight.transform);
            var Form = Tele.AddComponent<LineRenderer>();
            Form.startWidth = 0.001f;
            Form.alignment = 0;
            Form.material = new Material(Shader.Find("GUI/Text Shader"));
            Form.enabled = false;
            var TeleportLine = ControllerRight.AddComponent<LineRenderer>();
            TeleportLine.startWidth = 0.001f;
            TeleportLine.alignment = 0;
            TeleportLine.material = new Material(Shader.Find("GUI/Text Shader"));
            TeleportLine.enabled = false;
        }

        public static Ray ray;
        public static Ray Out;

        public static class InputInfo
        {
            public const string RightTrigger = "Oculus_CrossPlatform_SecondaryIndexTrigger";
            public const string LeftTrigger = "Oculus_CrossPlatform_PrimaryIndexTrigger";
        }       
    }
}
