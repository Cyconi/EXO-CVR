using ABI_RC.Core.Player;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Wrappers;


namespace EXO_CVR
{
    public partial class PlayerESP : MonoBehaviour
    {
        internal static bool DrawBox;
        internal static bool DrawLine;
        public static void OnGUI()
        {            
            foreach (PuppetMaster player in UnityEngine.Object.FindObjectsOfType(typeof(PuppetMaster)) as PuppetMaster[])
            {
                if (player == PlayerWrapper.LocalPlayer())
                    return; 
                        
                //In-Game Position
                Vector3 pivotPos = player.transform.position; //Pivot point NOT at the feet, at the center
                Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 0f; //At the feet
                Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head
                Vector3 playerChestPos; playerChestPos.x = pivotPos.x; playerChestPos.z = pivotPos.z; playerChestPos.y = pivotPos.y + 1f; //At the chest

                //Screen Position
                Vector3 w2s_playerpos = Camera.main.WorldToScreenPoint(pivotPos);
                Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                if (w2s_footpos.z > 0f)
                {
                    DrawBoxESP(w2s_playerpos, w2s_footpos, w2s_headpos, Color.red);
                }
            }                                  
        }

        public static void DrawBoxESP(Vector3 playerpos, Vector3 footpos, Vector3 headpos, Color color) //Rendering the ESP
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            //ESP BOX
            if (DrawLine)
                Render.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 2f);

            //Snapline
            if (DrawBox)
                Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(playerpos.x, (float)Screen.height - playerpos.y), color, 2f);            
        }        
    }
}
