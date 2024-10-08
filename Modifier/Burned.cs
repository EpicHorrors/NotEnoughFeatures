﻿using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;
using MiraAPI.Networking;
using NotEnoughFeatures.Options;
using static UnityEngine.GraphicsBuffer;

namespace NotEnoughFeatures.Modifier;

[RegisterModifier]
public class Burned : TimedModifier
{
    public override string ModifierName => "Burned";
    public override bool HideOnUi => false;
    public override float Duration => OptionGroupSingleton<DragonBurnOptions>.Instance.DieTimer;
    public override bool AutoStart => true;
    public override bool RemoveOnComplete => true;

    

    public override void OnTimerComplete()
    {
        if (Player.AmOwner)
        {
            Player.RpcCustomMurder(Player, createDeadBody: true, teleportMurderer: false, playKillSound: true, resetKillTimer: false, showKillAnim: true);
        }
    }
}
