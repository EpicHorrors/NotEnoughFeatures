using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class phaser : AbstractOptionGroup
{
    public override string GroupName => "Phaser";

    public override Type AdvancedRole => typeof(Phaser);

    [ModdedNumberOption("NoClip Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float Cooldown { get; set; } = 5;
    
    [ModdedNumberOption("NoClip Duration", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float NoclipDur { get; set; } = 5;

    
}