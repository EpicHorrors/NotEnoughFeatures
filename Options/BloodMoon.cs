using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using PhantomPlus.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class bloodmoon : AbstractOptionGroup
{
    public override string GroupName => "BloodMoon";

    public override Type AdvancedRole => typeof(BloodMoon);

    [ModdedNumberOption("Invisible Cooldown", 10, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float InvisCooldown { get; set; } = 5;

    [ModdedNumberOption("Invisible Duration", 5, 40, 1f, MiraNumberSuffixes.None)]
    public float InvisDur { get; set; } = 40;


}