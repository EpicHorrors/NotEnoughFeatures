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
using MiraAPI.Utilities;
using MiraAPI.Networking;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Absorb : CustomActionButton<PlayerControl>
{
    public override string Name => "Absorb";
    public override float Cooldown => OptionGroupSingleton<blackholeOptions>.Instance.Cooldown;
    public override float EffectDuration => 0;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.GarlicButton.png");
    public static bool shadows;

    public override ButtonLocation Location => ButtonLocation.BottomRight;

    public static Color forcedColor = Color.green;

    protected override void OnClick()
    {
        


        PlayerControl.LocalPlayer.RpcCustomMurder(Target, createDeadBody: false, teleportMurderer: true, playKillSound: true, resetKillTimer: true, showKillAnim: false);
    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.DisabledGrey));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }





    public override bool CanUse()
    {
        return base.CanUse() && TransformBH.isTransformed;
    }


    public override bool Enabled(RoleBehaviour role)
    {
        base.Button.buttonLabelText.SetFaceColor(Palette.Purple);
        return role is NotEnoughFeatures.Role.BlackHole;
    }
}