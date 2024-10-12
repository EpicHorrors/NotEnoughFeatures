using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;
using NotEnoughFeatures.Role;
using Il2CppSystem;
using UnityEngine;
using MiraAPI.Networking;

namespace NotEnoughFeatures.Modifier;

[RegisterModifier]
public class Hacked : TimedModifier
{
    public override string ModifierName => "Hacked";
    public override bool HideOnUi => false;
    public override float Duration => 60f;
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

        if (Player?.AmOwner == true || PlayerControl.LocalPlayer.Data.Role is Hacker)
        {
            Player?.cosmetics.SetOutline(true, new Nullable<Color>(Palette.AcceptedGreen));
        }
    }
    public override void OnTimerComplete()
    {
        if (Player.AmOwner)
        {
            Player.moveable = true;
            Player.RpcCustomMurder(Player, createDeadBody: false, teleportMurderer: false, playKillSound: true, resetKillTimer: true, showKillAnim: true);
        }
    }
}
