using ABI_RC.Core;
using ABI_RC.Systems.Camera.VisualMods;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using ABI_RC.Systems.MovementSystem;
using static Wrappers.PlayerWrapper;

namespace EXO_CVR.Modules
{
    internal class Movement : BaseModule
    {
        private static float _Time;
        private static int IsFly;
        public static float FlySpeed = 3f;
        internal static void BetterFly()
        {

            var PlayerPos = RootLogic.Instance.localPlayerRoot;
            if (PlayerPos == null) return;

            if (!Main.BFlyToggle) return;

            var Speed = Input.GetKey(KeyCode.LeftShift) ? FlySpeed * 3 : FlySpeed;

            MovementSystem.Instance.ChangeFlight(!MovementSystem.Instance.flying);
            if (XRDevice.isPresent)
            {
                PlayerPos.transform.position += new Vector3(0f, Time.deltaTime * Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") * FlySpeed);
            }
            else
            {
                if (Input.GetKey(KeyCode.Q))
                    PlayerPos.transform.position -= PlayerPos.transform.up / 250 * Speed;

                if (Input.GetKey(KeyCode.E))
                    PlayerPos.transform.position += PlayerPos.transform.up / 250 * Speed;
            }
        }
        public static float SpeedVal = 3f;
        internal static void Speed()
        {
            var PlayerPos = RootLogic.Instance.localPlayerRoot;
            if (PlayerPos == null) return;

            if (!Main.SpeedToggle) return;

            var PlayerTransform = PlayerPos.transform;

            if (XRDevice.isPresent)
            {
                PlayerTransform.position += PlayerTransform.forward * Time.deltaTime * Input.GetAxis("Vertical") * 6f;
                PlayerTransform.position += PlayerTransform.right * Time.deltaTime * Input.GetAxis("Horizontal") * 6f;
            }
            else
            {
                var speed = Input.GetKey(KeyCode.LeftShift) ? SpeedVal * 2 : SpeedVal;
                PlayerTransform.position += PlayerTransform.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed;
                PlayerTransform.position += PlayerTransform.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed;                
            }
        }
        internal static void JetPack()
        {
            var PlayerPos = RootLogic.Instance.localPlayerRoot;
            if (PlayerPos == null) return;

            if (!Main.JetPackToggle) return;

            if (Input.GetKey(KeyCode.Space))
                PlayerPos.transform.position += PlayerPos.transform.up / 35;
        }       
        public override void OnUpdate()
        {
            //keybinds
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
                IsFly++;                
                                            
            if (IsFly == 0)             
                return;
            //timer for keybinds
            _Time += Time.smoothDeltaTime;
            if (_Time > 0.2f)
            {
                IsFly = 0;
                _Time = 0;
            }
            else if (IsFly > 1)
            {
                Main.BFlyToggle = !Main.BFlyToggle;
                MovementSystem.Instance.ChangeFlight(!MovementSystem.Instance.flying);
                IsFly = 0;
                _Time = 0;                
            }            
        }
    }
}
