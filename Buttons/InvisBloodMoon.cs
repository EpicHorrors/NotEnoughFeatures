using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using PhantomPlus.Role;
using Reactor.Utilities;
using Rewired;
using TMPro;
using UnityEngine;
using NotEnoughFeatures;

using System.Collections;
using System;
using Reactor.Networking.Rpc;
using static MiraAPI.Example.ExamplePlugin;

namespace PhantomPlus.Buttons;

[RegisterButton]
public class InvisBloodMoon : CustomActionButton
{
    public override string Name => "Invisible";
    public override float Cooldown => OptionGroupSingleton<bloodmoon>.Instance.InvisCooldown;
    public override float EffectDuration => OptionGroupSingleton<bloodmoon>.Instance.InvisDur;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.InvisButton.png");
    public static bool shadows;

    

    protected override void OnClick()
    {
        //hacker/eclipse tp ability
        RpcInvis(PlayerControl.LocalPlayer);
        shadows = false;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(shadows);

    }

    

    public override void OnEffectEnd()
    {
        //hacker/eclipse tp ability
        RpcAppear(PlayerControl.LocalPlayer);
        shadows = true;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(shadows);
    }


    


    

    public override bool Enabled(RoleBehaviour role)
    {
        return role is BloodMoon;
    }
}