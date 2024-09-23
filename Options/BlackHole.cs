using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using PhantomPlus.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class BlackHole : AbstractOptionGroup
{
    public override string GroupName => "BlackHole";

    public override Type AdvancedRole => typeof(BlackHole);

    [ModdedNumberOption("Teleport Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float TeleportCooldown { get; set; } = 10;

    [ModdedNumberOption("Teleport Duration", 1, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float TeleportDuration { get; set; } = 40;

    [ModdedNumberOption("Zoom Distance", 1, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float ZoomDis { get; set; } = 40;

    [ModdedNumberOption("Transform Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float TransformCooldown { get; set; } = 10;

    [ModdedNumberOption("Transform Duration", 1, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float TransformDuration { get; set; } = 40;


}