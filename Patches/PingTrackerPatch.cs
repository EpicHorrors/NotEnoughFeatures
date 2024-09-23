using HarmonyLib;
using UnityEngine;
using TMPro;

using InnerNet;
using UnityEngine.UI;
using System;


using Object = UnityEngine.Object;

using AmongUs.Data;
using Assets.InnerNet;
using MiraAPI.Example;
using NotEnoughFeatures.API;





namespace PhantomPlus.Patches;

[HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
public class CreditsPatch
{

    

    public static string modName = $@"<size=130%><color=#00FFFF>NotEnoughFeatures</color>" + "<color=#FFFFFF>v1.1</color>";
    public static string Credits = $@"<size=70%><color=#39f>Modded by</color> <color=#FF0000>EpicHorrors</color><color=#39f>,</color> <color=#800080>Insanity</color> <color=#39f>&</color> <color=#808080>Techiee</color>";
    public static string design = $@"<size=70%><color=#39f>Design by</color> <color=#FF0000>EpicHorrors</color>";
    
    


    public static void Postfix(PingTracker __instance)
    {
        if (ExamplePlugin.ShowWatermark.Value && __instance != null)
        {
            __instance.text.alignment = TextAlignmentOptions.Top;
            var position = __instance.GetComponent<AspectPosition>();
            position.Alignment = AspectPosition.EdgeAlignments.Top;

            __instance.text.outlineWidth = 0.3f;
            __instance.text.outlineColor = Color.black;

            if (AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started)
            {
                position.DistanceFromEdge = new Vector3(2.25f, 0.11f, 0);
                CreditsAPI.PingTrackerCreditsInGame($@"<size=130%><color=#00FFFF>NotEnoughFeatures</color>" + "<color=#FFFFFF> v1.1</color>", __instance);
            }

            else
            {
                position.DistanceFromEdge = new Vector3(0f, 0.11f, 0);
                CreditsAPI.PingTrackerCreditsLobby($@"<size=130%><color=#00FFFF>NotEnoughFeatures</color>" + "<color=#FFFFFF> v1.1</color>", $@"<size=70%><color=#39f>Modded by</color> <color=#FF0000>EpicHorrors</color><color=#39f>,</color> <color=#800080>Insanity</color> <color=#39f>&</color> <color=#808080>Techiee</color>", $@"<size=70%><color=#39f>Design by</color> <color=#FF0000>EpicHorrors</color>", __instance);

            }
        }

        

    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class menuCre
    {
        public static SpriteRenderer renderer;
        public static Sprite bannerSprite;
        private static PingTracker instance;
        private static AnnouncementPopUp popUp;


        public static void Postfix(PingTracker __instance)
        {





            var torLogo = new GameObject("bannerLogo_TOR");

            torLogo.transform.localPosition = new Vector3(2.0855f, 0f, 0f);

            renderer = torLogo.AddComponent<SpriteRenderer>();
            loadSprites();
            renderer.sprite = Utils.loadSpriteFromResources("NotEnoughFeatures.Resources.notenoughfeature.png", 300f);

            instance = __instance;
            loadSprites();







        }

        public static void loadSprites()
        {
            if (bannerSprite == null) bannerSprite = Utils.loadSpriteFromResources("PhantomPlus.Resources.notenoughfeature.png", 300f);

        }


        













    }
}


