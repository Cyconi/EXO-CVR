using EXO_CVR.PatchAPI.Patches;
using HarmonyLib;
using MelonLoader;
using System;
using System.Reflection;

namespace EXO_CVR.PatchAPI
{
    internal class EXOPatch
    {
        public static HarmonyLib.Harmony Instance = new HarmonyLib.Harmony("x86");

        public static HarmonyMethod GetLocalPatch(Type type, string methodName) => new HarmonyMethod(type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic));
        public static void StartPatches()
        {
            try
            {
                MelonLogger.Log("[Patches] ~> Starting Patches...");
                _NetworkedEvent.Init();
            }
            catch (Exception e)
            {

            }
        }
    }
}
