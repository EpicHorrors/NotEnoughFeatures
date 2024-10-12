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
public class Fart : CustomActionButton
{
    public override string Name => "Fart";
    public override float Cooldown => OptionGroupSingleton<EmoteOptions>.Instance.fartCooldown;
    public override float EffectDuration => OptionGroupSingleton<EmoteOptions>.Instance.fartduration;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.GarlicButton.png");
    public static bool shadows;

    public override ButtonLocation Location => ButtonLocation.BottomRight;

    public static Color forcedColor = Color.green;

    protected override void OnClick()
    {
        forcedColor = Color.green;
        Button.cooldownTimerText.color = forcedColor;
        //hacker/eclipse tp ability
        RpcFart(PlayerControl.LocalPlayer);
        

    }

    

    public override void OnEffectEnd()
    {
        //hacker/eclipse tp ability
        RpcEndFart(PlayerControl.LocalPlayer);
        Button.cooldownTimerText.color = Color.white;
    }


    


    

    public override bool Enabled(RoleBehaviour role)
    {
        return role;
    }
}