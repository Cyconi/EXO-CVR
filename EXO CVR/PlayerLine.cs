using ABI_RC.Core.Player;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using Wrappers;


namespace EXO_CVR
{
    internal class PlayerLine
    {
        internal static bool State;

        internal static IEnumerator Init()
        {            
            if (Load.ControllerLeft == null || Load.ControllerRight == null || !XRDevice.isPresent)
                Load.AssignBindings();
            if (!State)
                yield return null;
            while (State)
            {
                foreach (CVRPlayerEntity player in CVRPlayerManager.Instance.GetAllPlayers())
                { 
                    try
                    {
                        if (XRDevice.isPresent)
                            GetPlayerReady(player).SetPosition(1, GetContoller().position);
                        else
                            GetPlayerReady(player).SetPosition(1, Camera.current.transform.position + Camera.current.transform.forward * 0.3f);

                        GetPlayerReady(player).SetPosition(0, player.PlayerObject.transform.position/*player.field_Private_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.Hips).position*/);

                    }
                    catch { MelonLogger.Msg("Bruhhhh"); }
                } 
                yield return new WaitForEndOfFrame();
            }
            Disable();
            yield break; 
        }

        internal static void Disable()
        {
            foreach (PuppetMaster Player in UnityEngine.Object.FindObjectsOfType(typeof(PuppetMaster)) as PuppetMaster[])
                GameObject.Destroy(Player.gameObject.GetComponent<LineRenderer>());
        }
        private static Transform GetContoller() =>
             Load.ControllerRight.transform;

        internal static LineRenderer GetPlayerReady(CVRPlayerEntity Player)
        {
            var LineRenderComp = Player.PlayerObject.GetOrAddComponents<LineRenderer>();
            LineRenderComp.enabled = true;
            LineRenderComp.startWidth = 0.006f;
            LineRenderComp.alignment = 0;
            LineRenderComp.material = new Material(Shader.Find("GUI/Text Shader"));
            LineRenderComp.material.color = Color.red;
            return LineRenderComp;
        }                
    }
}
