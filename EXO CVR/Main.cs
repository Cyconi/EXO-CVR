using EXO_CVR.Modules;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EXO_CVR
{
    public class Main : BaseModule
    {
        internal static bool BFlyToggle = false;
        internal static bool SpeedToggle = false;
        internal static bool PlayerESPToggle = false;
        internal static bool NoClipToggle = false;
        internal static bool FloorDropToggle = false;
        internal static bool JetPackToggle = false;
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(WindowName.WindowName.ChangeTitle());
            MelonCoroutines.Start(LoadedUI());
        }
        internal static IEnumerator LoadedUI()
        {
            while (GameObject.Find("/Cohtml") == null)
            {
                yield return null;
            }
            MelonLogger.Msg("[ Menus Loaded ]");
            MenuLoaded();
            yield break;
        }
        internal static void MenuLoaded()
        {
            MelonLogger.Msg("");
            MelonLogger.Msg("");
            MelonLogger.Msg("");
            MelonLogger.Msg("[============================================================================]");
            MelonLogger.Msg("[                                                                            ]");
            MelonLogger.Msg("[                                                                            ]");
            MelonLogger.Msg("[      [-]  $$$$\\       $$$$$$$$\\ $$\\   $$\\  $$$$$$\\        $$$$\\   [-]      ]");
            MelonLogger.Msg("[      [-]  $$  _|      $$  _____|$$ |  $$ |$$  __$$\\       \\_$$ |  [-]      ]");
            MelonLogger.Msg("[      [-]  $$ |        $$ |      \\$$\\ $$  |$$ /  $$ |        $$ |  [-]      ]");
            MelonLogger.Msg("[      [-]  $$ |        $$$$$\\     \\$$$$  / $$ |  $$ |        $$ |  [-]      ]");
            MelonLogger.Msg("[      [-]  $$ |        $$  __|    $$  $$<  $$ |  $$ |        $$ |  [-]      ]");
            MelonLogger.Msg("[      [-]  $$ |        $$ |      $$  /\\$$\\ $$ |  $$ |        $$ |  [-]      ]");
            MelonLogger.Msg("[      [-]  $$$$\\       $$$$$$$$\\ $$ /  $$ | $$$$$$  |      $$$$ |  [-]      ]");
            MelonLogger.Msg("[      [-]  \\____|      \\________|\\__|  \\__| \\______/       \\____|  [-]      ]");
            MelonLogger.Msg("[                                                                            ]");
            MelonLogger.Msg("[                                                                            ]");
            MelonLogger.Msg("[============================================================================]");
            MelonLogger.Msg("");
            MelonLogger.Msg("");
            MelonLogger.Msg("[================================== KeyBind =================================]");
            MelonLogger.Msg("[                                                                            ]");
            MelonLogger.Msg("[                          Hold TAB    =    Access GUI                       ]");
            MelonLogger.Msg("[                          2x Jump     =    Fly                              ]");
            MelonLogger.Msg("[                                                                            ]");
            MelonLogger.Msg("[================================== KeyBind =================================]");
            MelonLogger.Msg("");
            MelonLogger.Msg("");
            MelonLogger.Msg("");
        }

        public override void OnGUI()
        {
            GUI.Box(new Rect(5f, 30f, 100f, 25f), "");
            GUI.Box(new Rect(5f, 65f, 100f, 25f), "");
            GUI.Box(new Rect(5f, 100f, 100f, 25f), "");
            GUI.Box(new Rect(5f, 135f, 100f, 25f), "");
            GUI.Box(new Rect(5f, 170f, 100f, 25f), "");

            Render.DrawBox(5f, 30f, 100f, 25f, Color.red, 3f);
            Render.DrawBox(5f, 65f, 100f, 25f, Color.red, 3f);
            Render.DrawBox(5f, 100f, 100f, 25f, Color.red, 3f);
            Render.DrawBox(5f, 135f, 100f, 25f, Color.red, 3f);
            Render.DrawBox(5f, 170f, 100f, 25f, Color.red, 3f);

            if (GUI.Button(new Rect(120f, 31f, 100f, 30f), "Quit"))
            {                
                //Process.Start(Directory.GetCurrentDirectory() + "\\ChilloutVR.exe");
                Process.GetCurrentProcess().Kill();
            }

            if (GUI.Button(new Rect(120f, 66f, 100f, 30f), "3D Line ESP"))
            {
                FloorDropToggle = !FloorDropToggle;
                if (FloorDropToggle)
                {
                    PlayerLine.State = true;
                    MelonCoroutines.Start(PlayerLine.Init());
                    MelonLogger.Msg("ON");
                }
                if (!FloorDropToggle)
                {
                    PlayerLine.State = false;
                    MelonCoroutines.Start(PlayerLine.Init());
                    MelonLogger.Msg("OFF");
                }
            }

            BFlyToggle = GUI.Toggle(new Rect(7f, 32f, 100f, 30f), BFlyToggle, "FlyBinds");
            if (BFlyToggle) 
                Movement.BetterFly();

            SpeedToggle = GUI.Toggle(new Rect(7f, 67f, 100f, 30f), SpeedToggle, "Speed");
            if (SpeedToggle) 
                Movement.Speed();

            PlayerESPToggle = GUI.Toggle(new Rect(7f, 102f, 100f, 30f), PlayerESPToggle, "LineESP");
            if (PlayerESPToggle) 
            {
                PlayerESP.DrawBox = true;
                PlayerESP.OnGUI(); 
            }
            else
                PlayerESP.DrawBox = false;

            NoClipToggle = GUI.Toggle(new Rect(7f, 137f, 100f, 30f), NoClipToggle, "BoxESP");
            if (NoClipToggle)
            {
                PlayerESP.DrawLine = true;
                PlayerESP.OnGUI();
            }
            else
                PlayerESP.DrawLine = false;

            JetPackToggle = GUI.Toggle(new Rect(7f, 172f, 100f, 30f), JetPackToggle, "JetPack");
            if (JetPackToggle)
                Movement.JetPack();
        }
    }
}
// What to add
// edwards capsule ESP on a Toggle
// 3D Line ESP
// fix fly
// add item tp and esp
