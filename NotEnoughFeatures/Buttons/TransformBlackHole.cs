using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using PhantomPlus.Role;
using Reactor.Utilities;
using System.Collections;
using PhantomPlus.Patches;
using UnityEngine;

namespace MiraAPI.Example.Buttons.Teleporter;
[RegisterButton]
public class TransformBlackHole : CustomActionButton
{
    public override string Name => "Transform";

    public override float Cooldown => OptionGroupSingleton<NotEnoughFeatures.Options.NorthernBreeze.BlackHole>.Instance.TransformCooldown;

    public override float EffectDuration => OptionGroupSingleton<NotEnoughFeatures.Options.NorthernBreeze.BlackHole>.Instance.TransformDuration;

    public override int MaxUses => 0;
    public static GameObject kraken;

    public override LoadableAsset<Sprite> Sprite => new LoadableResourceAsset("NotEnoughFeatures.Resources.O2.png");
    public static bool IsZoom { get; private set; }
    
    public override bool Enabled(RoleBehaviour role)
    {
        return role is PhantomPlus.Role.BlackHole;
    }
    protected override void OnClick()
    {


        foreach (var renderer in PlayerControl.LocalPlayer.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        var render = PlayerControl.LocalPlayer.GetComponent<SpriteRenderer>();
        

        

        kraken = new GameObject("Kraken");
        var spriteRenderer = kraken.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Utils.LoadSpriteIntoGame("NotEnoughFeatures.Resources.BlackHole.png", 200);
        spriteRenderer.sortingOrder = 10;

        kraken.transform.SetParent(PlayerControl.LocalPlayer.transform);


        
        kraken.transform.localPosition = Vector3.zero;

        

    }

    public override void OnEffectEnd()
    {
        foreach (var renderer in PlayerControl.LocalPlayer.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = true;
            
            GameObject.Destroy(kraken);
        }
    }

    
}