using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reactor;
using UnityEngine;
using TMPro;
using System.Collections;
using Rewired.Data.Mapping;
using Il2CppSystem;
using Reactor.Utilities.Attributes;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using UnityEngine.TextCore;


namespace PhantomPlus;


[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[HarmonyPatch(typeof(MeetingHud))]
[HarmonyPatch("Update")]
[HarmonyPatch(typeof(HudManager), nameof(HudManager.Start))]


public partial class PhantomPlusPlugin : BasePlugin
{
    public static float zoom = 3f;
    public static bool toggleShadows = false;

    public static int count = 0;

    public Harmony Harmony { get; } = new Harmony(Id);

    public ConfigEntry<string> ConfigName { get; private set; }



    public override void Load()
    {
        ConfigName = Config.Bind("Fake", "Name", "");


        Harmony.PatchAll();
    }

    [HarmonyPatch(typeof(PhantomRole), nameof(PhantomRole.isInvisible))]





    private string GetDebuggerDisplay()
    {
        return ToString();
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    

    public static class PlayerStuffPatch
    {
        public static void Postfix()
        {
            Camera.main.orthographicSize = zoom;
        }

    }

    [HarmonyPatch(typeof(KeyboardJoystick), nameof(KeyboardJoystick.Update))]
    public static class ZoomPatch
    {


        public static void Postfix()
        {

            if (Input.GetKey(KeyCode.Z)) //zoomOut
            {
                zoom = zoom + 6 * Time.deltaTime;
                toggleShadows = false;
                HudManager.Instance.ShadowQuad.gameObject.SetActive(toggleShadows);
            }

            if (Input.GetKey(KeyCode.X)) //zoomIn
            {
                zoom = zoom - 6 * Time.deltaTime;
                toggleShadows = false;
                HudManager.Instance.ShadowQuad.gameObject.SetActive(toggleShadows);
            }

            if (Input.GetKeyDown(KeyCode.C)) //normal fov
            {
                zoom = zoom = 3;

            }
            

            if (zoom <= 3) //checking
            {
                toggleShadows = false;
                HudManager.Instance.ShadowQuad.gameObject.SetActive(toggleShadows);
            }

            if (zoom >= 3)//checking
            {
                toggleShadows = false;
                HudManager.Instance.ShadowQuad.gameObject.SetActive(toggleShadows);
            }

            if (zoom == 3)//checking
            {
                toggleShadows = true;
                HudManager.Instance.ShadowQuad.gameObject.SetActive(toggleShadows);
            }





        }
    }




    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public class CreditsPatch
    {
        public static void Postfix(PingTracker __instance)
        {
            __instance.text.alignment = TextAlignmentOptions.Center;
            __instance.text.text += "<color=#00FFFF>" + "\nNotEnoughFeature v1.0" + "</color>"; // Cyan color
            __instance.text.text += "<color=#FF0000>" + "\nMod by EpicHorrors" + "</color>"; // Red color
        }
    }

}