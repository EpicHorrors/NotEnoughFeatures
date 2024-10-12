using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class InvisOptions : AbstractOptionGroup
{
    public override string GroupName => "Invisible";

    public override Type AdvancedRole => typeof(Invisiblility);

    [ModdedNumberOption("Invis Cooldown", 15, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float InvisCooldown { get; set; } = 30;

    [ModdedNumberOption("Invis Duration", 10, 40, 2f, MiraNumberSuffixes.Seconds)]
    public float InvisDur { get; set; } = 10;

    


}