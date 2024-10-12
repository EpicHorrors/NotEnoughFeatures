using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class janitor : AbstractOptionGroup
{
    public override string GroupName => "Janitor";

    public override Type AdvancedRole => typeof(Sniper);

    [ModdedNumberOption("Clean Cooldown", 10, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float KillCooldown { get; set; } = 10;
    
    

    
}