using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

using System.Linq;
using UnityEngine;
using PhantomPlus.Patches;

using UnityEngine.UI;


namespace PhantomPlus;


[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]

[HarmonyPatch(typeof(MeetingHud))]
[HarmonyPatch("Update")]





public partial class PhantomPlusPlugin : BasePlugin
{

    public static Sprite killButton;
    public static Sprite sabotageButton;
    public static Sprite useButton;
    
    


    public Harmony Harmony { get; } = new Harmony(Id);

   


    public override void Load()
    {
        

        Harmony.PatchAll();
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    





    public static class buttonSprite
    {
        public static void Postfix()
        {
            
            //kill button
            killButton = Utils.loadSpriteFromResources("PhantomPlus.Resources.burn.png", 300f);

            HudManager.Instance.UseButton.buttonLabelText.text = "Interact";

            HudManager.Instance.KillButton.graphic.sprite = killButton;
            
            HudManager.Instance.KillButton.buttonLabelText.text = "Burn";

            HudManager.Instance.KillButton.graphic.SetCooldownNormalizedUvs();


            //sabotage button
            sabotageButton = Utils.loadSpriteFromResources("PhantomPlus.Resources.sabotage button_custom.png", 600f);

            

            HudManager.Instance.SabotageButton.graphic.sprite = sabotageButton;

            

            HudManager.Instance.SabotageButton.graphic.SetCooldownNormalizedUvs();

            //use button
            useButton = Utils.loadSpriteFromResources("PhantomPlus.Resources.useButton.png", 400f);



            HudManager.Instance.UseButton.graphic.sprite = useButton;



            HudManager.Instance.UseButton.graphic.SetCooldownNormalizedUvs();

        }
    }

    
}