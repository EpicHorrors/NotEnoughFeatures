using HarmonyLib;
using UnityEngine;
using PhantomPlus.Patches;

namespace PhantomPlus.Buttons;

public partial class ButtonTextAndPosition
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Start))]
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]



    public static class PlayerControlPatch
    {
        public static void Postfix()
        {


            

            Vector2 positionAbilityButton = new Vector3(-9.1f, 0f, -9f);

            HudManager.Instance.AbilityButton.transform.localPosition = positionAbilityButton;



            


            Vector2 positionVentButton = new Vector3(-1f, 1f, -9f);

            HudManager.Instance.ImpostorVentButton.transform.localPosition = positionVentButton;


            

            
        }

        

    }
}