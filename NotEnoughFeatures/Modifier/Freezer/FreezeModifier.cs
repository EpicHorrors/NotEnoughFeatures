using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;
using NotEnoughFeatures.Role;
using Il2CppSystem;
using UnityEngine;
using MiraAPI.Networking;

namespace NotEnoughFeatures.Modifier.Freezer;

[RegisterModifier]
public class Freezed : TimedModifier
{
    public override string ModifierName => "Freezed";
    public override bool HideOnUi => false;
    public override float Duration => 1000f;
    public override bool AutoStart => true;
    public override bool RemoveOnComplete => true;

    public override void OnActivate()
    {
        if (Player.AmOwner)
        {
            Player.moveable = false;
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Player?.AmOwner == true || PlayerControl.LocalPlayer.Data.Role is NothernBreeze)
        {
            Player?.cosmetics.SetOutline(true, new Nullable<Color>(Palette.LightBlue));
        }
    }

    public override void OnTimerComplete()
    {
        if (Player.AmOwner)
        {
            Player.moveable = true;
            Player.RpcCustomMurder(Player, createDeadBody: true, teleportMurderer: false, playKillSound: false, resetKillTimer: false, showKillAnim: true);
        }
    }
}
