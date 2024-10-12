using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class virus : AbstractOptionGroup
{
    public override string GroupName => "Virus";

    public override Type AdvancedRole => typeof(Virus);

    [ModdedNumberOption("Infect Cooldown", 1, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float InfectCooldown { get; set; } = 1;

    


}