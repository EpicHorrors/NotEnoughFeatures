using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options;

public class Freeze : AbstractOptionGroup
{
    public override string GroupName => "Freeze";

    public override Type AdvancedRole => typeof(NothernBreeze);

    [ModdedNumberOption("Freezed Duration", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float FreezedDuration { get; set; } = 5;


    [ModdedNumberOption("Freeze Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float FreezeCooldown { get; set; } = 5;


}