using HarmonyLib;
using UnityEngine;
using TMPro;
using System.Text;
using Il2CppSystem.Web.Util;
using PhantomPlus.Patches;
using InnerNet;




namespace PhantomPlus.Patches;

[HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
public class CreditsPatch
{

    

    public static string modName = $@"<size=130%><color=#00FFFF>NotEnoughFeatures</color> <color=#FFFFFF>v1.1</color>";
    public static string credit = $@"<size=60%><color=#0000FF>Modded by</color> <color=#FF0000>EpicHorrors</color><color=#0000FF>, </color> <color=#A020F0>TheLegend</color> <color=#0000FF>&</color> <color=#808080>〒∈⊂卄∥∈∈</color>";
    public static string thanks = $@"<color=#FFFF00>Thanks to all modders that help me</color>";
    public static string design = $@"<color=#0000FF>Design by</color> <color=#FF0000>EpicHorrors</color>";



    public static void Postfix(PingTracker __instance)
    {
        __instance.text.alignment = TextAlignmentOptions.Top;
        var position = __instance.GetComponent<AspectPosition>();
        position.Alignment = AspectPosition.EdgeAlignments.Top;
        position.DistanceFromEdge = new Vector3(0f, 0.1f, 0);
        __instance.text.outlineWidth = 0.3f;
        __instance.text.outlineColor = Color.black;


        position.AdjustPosition();
        var host = GameData.Instance?.GetHost();


        
        

        __instance.text.text = $"{modName}\n{credit}\n{design}\n{thanks}\n {__instance.text.text}";


        


        




    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class menuCre
    {
        public static SpriteRenderer renderer;
        public static Sprite bannerSprite;
        private static PingTracker instance;


        public static void Postfix(PingTracker __instance)
        {





            var torLogo = new GameObject("bannerLogo_TOR");

            torLogo.transform.localPosition = new Vector3(2.0855f, 0f, 0f);

            renderer = torLogo.AddComponent<SpriteRenderer>();
            loadSprites();
            renderer.sprite = Utils.loadSpriteFromResources("PhantomPlus.Resources.notenoughfeature.png", 300f);

            instance = __instance;
            loadSprites();







        }

        public static void loadSprites()
        {
            if (bannerSprite == null) bannerSprite = Utils.loadSpriteFromResources("PhantomPlus.Resources.notenoughfeature.png", 300f);

        }
    }






}
