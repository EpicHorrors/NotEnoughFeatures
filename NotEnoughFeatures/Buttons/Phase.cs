using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using Rewired;
using TMPro;
using UnityEngine;
using NotEnoughFeatures;

using System.Collections;
using System;
using Reactor.Networking.Rpc;
using static NotEnoughFeatures.NotEnoughFeaturesPlugin;


namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Phase : CustomActionButton
{
    public override string Name => "Noclip";
    public override float Cooldown => OptionGroupSingleton<phaser>.Instance.Cooldown;
    public override float EffectDuration => OptionGroupSingleton<phaser>.Instance.NoclipDur;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.noclipmod.png");
    
    public static bool shadows;
    public static bool IsZoom { get; private set; }
    public static Color forcedColor = Color.green;
    protected override void OnClick()
    {
        forcedColor = Color.green;
        Button.cooldownTimerText.color = forcedColor;
        //hacker/eclipse tp ability
        
        shadows = false;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(shadows);
        var rigidbody2d = PlayerControl.LocalPlayer.GetComponent<Rigidbody2D>();
        rigidbody2d.isKinematic = true;
    }

    

    public override void OnEffectEnd()
    {
        //hacker/eclipse tp ability
        Button.cooldownTimerText.color = Color.white;
        

        shadows = true;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(shadows);
        var rigidbody2d = PlayerControl.LocalPlayer.GetComponent<Rigidbody2D>();
        rigidbody2d.isKinematic = false;
    }



    


    public override bool Enabled(RoleBehaviour role)
    {
        return role is Phaser;
    }
}