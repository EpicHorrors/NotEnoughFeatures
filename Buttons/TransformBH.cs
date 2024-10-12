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
public class TransformBH : CustomActionButton
{
    public override string Name => "Transform";
    public override float Cooldown => OptionGroupSingleton<blackholeOptions>.Instance.TransCooldown;
    public override float EffectDuration => OptionGroupSingleton<blackholeOptions>.Instance.Transdur;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.BlackHole_Button.png", 350);
    public static bool shadows;

    public static bool isTransformed;

    public static Color forcedColor = Color.green;

    protected override void OnClick()
    {
        forcedColor = Color.green;
        Button.cooldownTimerText.color = forcedColor;
        //hacker/eclipse tp ability
        Rpctransform(PlayerControl.LocalPlayer);
        
        isTransformed = true;
    }

    

    public override void OnEffectEnd()
    {
        //hacker/eclipse tp ability
        RpcStoptransform(PlayerControl.LocalPlayer);
        Button.cooldownTimerText.color = Color.white;
        isTransformed = false;
    }



    public override void FixedUpdateHandler(PlayerControl playerControl)
    {
        base.FixedUpdateHandler(playerControl);

        if (Input.GetKey(KeyCode.A))
        {
            var sprite = ExamplePlugin.gogogo.GetComponent<SpriteRenderer>();
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            var sprite = ExamplePlugin.gogogo.GetComponent<SpriteRenderer>();
            sprite.flipX = true;
        }
    }



    public override bool Enabled(RoleBehaviour role)
    {
        base.Button.buttonLabelText.SetFaceColor(Palette.Purple);
        return role is BlackHole;
    }
}