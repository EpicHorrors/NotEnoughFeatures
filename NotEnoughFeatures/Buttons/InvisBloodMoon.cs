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
using static NotEnoughFeatures.ExamplePlugin;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class InvisBloodMoon : CustomActionButton
{
    public override string Name => "Invisible";
    public override float Cooldown => OptionGroupSingleton<bloodmoon>.Instance.InvisCooldown;
    public override float EffectDuration => OptionGroupSingleton<bloodmoon>.Instance.InvisDur;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.InvisButton.png");
    public static bool shadows;

    public static Color forcedColor = Color.green;

    protected override void OnClick()
    {
        //hacker/eclipse tp ability
        RpcInvis(PlayerControl.LocalPlayer);
        shadows = false;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(shadows);
        forcedColor = Color.green;
        Button.cooldownTimerText.color = forcedColor;
        var rigidbody2d = PlayerControl.LocalPlayer.GetComponent<Rigidbody2D>();
        rigidbody2d.isKinematic = true;
        
    }

    

    public override void OnEffectEnd()
    {
        //hacker/eclipse tp ability
        Button.cooldownTimerText.color = Color.white;
        RpcAppear(PlayerControl.LocalPlayer);
        shadows = true;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(shadows);
        var rigidbody2d = PlayerControl.LocalPlayer.GetComponent<Rigidbody2D>();
        rigidbody2d.isKinematic = false;
    }


    


    

    public override bool Enabled(RoleBehaviour role)
    {
        base.Button.buttonLabelText.SetFaceColor(Palette.ImpostorRoleHeaderVeryDarkRed);
        return role is BloodMoon;
    }
}