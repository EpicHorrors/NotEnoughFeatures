using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class assasinate : AbstractOptionGroup
{
    public override string GroupName => "Assasinate";

    public override Type AdvancedRole => typeof(Assasin);

    [ModdedNumberOption("Assasinate Cooldown", 0, 60, 2.5f, MiraNumberSuffixes.Seconds)]
    public float AssasinateCooldown { get; set; } = 5;

    [ModdedNumberOption("Assasinate Uses", 1, 6, 1f, MiraNumberSuffixes.None)]
    public float AssasinateUses { get; set; } = 1;


}