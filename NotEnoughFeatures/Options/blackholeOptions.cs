using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class blackholeOptions : AbstractOptionGroup
{
    public override string GroupName => "BlackHole";

    public override Type AdvancedRole => typeof(Shade);

    [ModdedNumberOption("Absorb Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float Cooldown { get; set; } = 20;
    
    [ModdedNumberOption("Warp Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float WarpCooldown { get; set; } = 5;

    [ModdedNumberOption("Warp Duration", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float Warpdur { get; set; } = 15;

    [ModdedNumberOption("Zoom Distance", 0, 15, 2.5f, MiraNumberSuffixes.None)]
    public float Zoomdis { get; set; } = 12;

    [ModdedNumberOption("Transform Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float TransCooldown { get; set; } = 1;

    [ModdedNumberOption("Transform Duration", 0, 100, 2.5f, MiraNumberSuffixes.Seconds)]
    public float Transdur { get; set; } = 30;
}