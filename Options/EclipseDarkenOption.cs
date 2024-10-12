using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options;

public class EclipseDarkenOption : AbstractOptionGroup
{
    public override string GroupName => "Darken";

    public override Type AdvancedRole => typeof(Eclipse);

    [ModdedNumberOption("Darken Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float DarkenCooldown { get; set; } = 5;

    [ModdedNumberOption("Evaporate Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float EvaporateCooldown { get; set; } = 5;


}