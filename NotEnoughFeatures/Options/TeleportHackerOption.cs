using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options;

public class TeleporterHackerOption : AbstractOptionGroup
{
    public override string GroupName => "Teleport";

    public override Type AdvancedRole => typeof(Hacker);

    [ModdedNumberOption("Teleport Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float TeleportCooldown { get; set; } = 5;

    [ModdedNumberOption("Teleport Duration", 5, 25, 1, MiraNumberSuffixes.Seconds)]
    public float TeleportDuration { get; set; } = 10;

    [ModdedNumberOption("Hack Duration", 5, 30, 1, MiraNumberSuffixes.Seconds)]
    public float HackDuration { get; set; } = 10;

    [ModdedNumberOption("Zoom Distance", 4, 15)]
    public float ZoomDistance { get; set; } = 6;
}