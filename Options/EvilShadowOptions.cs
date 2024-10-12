using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class evilshadow : AbstractOptionGroup
{
    public override string GroupName => "EvilShadow";

    public override Type AdvancedRole => typeof(EvilShadow);

    [ModdedNumberOption("Zoom Cooldown", 10, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float ZoomCooldown { get; set; } = 20;

    [ModdedNumberOption("Zoom Duration", 10, 60, 1f, MiraNumberSuffixes.None)]
    public float ZoomDur { get; set; } = 15;

    [ModdedNumberOption("Zoom Distance", 5, 20, 1f, MiraNumberSuffixes.None)]
    public float ZoomDis { get; set; } = 15;

    [ModdedNumberOption("Shadow Cooldown", 20, 60, 2f, MiraNumberSuffixes.None)]
    public float ShadowCool { get; set; } = 15;


    [ModdedNumberOption("Corrupt Cooldown", 10, 60, 2f, MiraNumberSuffixes.None)]
    public float CorruptCool { get; set; } = 15;


}