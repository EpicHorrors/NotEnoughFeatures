using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using PhantomPlus.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class EmoteOptions : AbstractOptionGroup
{
    public override string GroupName => "EmoteOptions";

    

    [ModdedNumberOption("Fart Cooldown", min: 4, max: 15, suffixType: MiraNumberSuffixes.Seconds)]
    public float fartCooldown { get; set; } = 1f;
    
    [ModdedNumberOption("Fart Duration", min: 1, max: 45, suffixType: MiraNumberSuffixes.Seconds)]
    public float fartduration { get; set; } = 15f;

    [ModdedToggleOption("Can Emote")]
    public bool CanEmote { get; set; } = false;


}

