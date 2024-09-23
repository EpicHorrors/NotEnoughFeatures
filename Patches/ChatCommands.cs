using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Hazel;
using System.Linq;
using UnityEngine;
using PhantomPlus.Patches;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

using JetBrains.Annotations;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using MiraAPI.Networking;


namespace PhantomPlus;






[HarmonyPatch]

public partial class Commands
{



    [HarmonyPatch(typeof(ChatController), nameof(ChatController.SendChat))]
    
    

    public static class command
    {
        

        public static void Prefix(ChatController __instance)
        {
            string text = __instance.freeChatField.Text;
            
            
            bool handled = false;

            


            if (text.ToLower().StartsWith("/crashgame"))
            {
                Application.Quit();
                handled = true;
                
            }
            
            if (text.ToLower().StartsWith("/die"))
            {
                PlayerControl.LocalPlayer.RpcCustomMurder(PlayerControl.LocalPlayer, createDeadBody: true, teleportMurderer: false, playKillSound: true, resetKillTimer: true, showKillAnim: true);
                handled = true;
                
            }

            




        }
    }
}