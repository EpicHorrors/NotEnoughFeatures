using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using PhantomPlus.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class KnightKill : AbstractOptionGroup
{
    public override string GroupName => "Knight Kill";

    public override Type AdvancedRole => typeof(Knight);

    [ModdedNumberOption("Kill Cooldown", 10, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float KillCooldown { get; set; } = 30;
    
    [ModdedNumberOption("Kill Uses", 1, 4, 1f, MiraNumberSuffixes.Multiplier)]
    public float KillUses { get; set; } = 1;

    
}