using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options;

public class DragonBurnOptions : AbstractOptionGroup
{
    public override string GroupName => "Burn";

    public override Type AdvancedRole => typeof(Dragon);

    [ModdedNumberOption("DieTimer", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float DieTimer { get; set; } = 5;

    [ModdedNumberOption("Burn Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float BurnCooldown { get; set; } = 5;


}