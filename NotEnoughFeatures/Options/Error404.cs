using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class HackerKill : AbstractOptionGroup
{
    public override string GroupName => "Error404";

    public override Type AdvancedRole => typeof(Hacker);

    [ModdedNumberOption("Kill Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float Cooldown { get; set; } = 5;
    
    [ModdedNumberOption("DeleteMap Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float MapCooldown { get; set; } = 5;

    
}