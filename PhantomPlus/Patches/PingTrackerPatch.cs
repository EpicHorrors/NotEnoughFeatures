using HarmonyLib;
using UnityEngine;
using TMPro;
using System.Text;

namespace PhantomPlus.Patches;

[HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
public class CreditsPatch
{



    public static void Postfix(PingTracker __instance)
    {
        var position = __instance.GetComponent<AspectPosition>();
        position.DistanceFromEdge = new Vector3(0f, 5.8544f, 0);
        
        position.AdjustPosition();
        var host = GameData.Instance?.GetHost();

        

        __instance.text.outlineColor = Color.black;

        __instance.text.outlineWidth = 0.4f;

        __instance.text.alignment = TextAlignmentOptions.Center;

        __instance.text.text += $"<size=130%><color=#00FFFF>\nNotEnoughFeature</color> <color=#FFFFFF>v1.1</color>";


        __instance.text.text += $"<size=60%>\nModded by <color=#FF0000>EpicHorrors</color>, <color=#A020F0>TheLegend</color> & <color=#808080>Techiee</color> \nDesign by <color=#FF0000>EpicHorrors</color> <color=#FFFF00>\nThanks to all modders that help me</color>";




        


    }



}