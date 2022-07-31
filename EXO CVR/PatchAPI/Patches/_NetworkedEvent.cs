using DarkRift;
using DarkRift.Client;
using Dissonance.Datastructures;
using Dissonance.Integrations.DarkRift2;
using EXO_CVR.FishsCumCorner.Config;
using HarmonyLib;
using JetBrains.Annotations;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXO_CVR.PatchAPI.Patches
{
    internal class _NetworkedEvent
    {
        private readonly ConcurrentPool<byte[]> _byteBuffers = new ConcurrentPool<byte[]>(3, () => new byte[4096]);
        public static void Init()
        {
            EXOPatch.Instance.Patch(typeof(DarkRift2Client).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(_NetworkedEvent), nameof(OnEvent))));
        }
        public void OnEvent(object sender, [NotNull] MessageReceivedEventArgs e)
        {
            MelonLogger.Log($"[Packets Recieved]------START------\nSender: {sender}\nRAW: {e}\n------END------");
        }
    }
}
