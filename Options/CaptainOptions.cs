using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using PhantomPlus.Role;
using System;

namespace NotEnoughFeatures.Options;

public class CaptainOptions : AbstractOptionGroup
{
    public override string GroupName => "Meetings";

    public override Type AdvancedRole => typeof(Captain);

    [ModdedNumberOption("Meeting Cooldown", 5, 60, 1f, MiraNumberSuffixes.Seconds)]
    public float MeetingCooldown { get; set; } = 40;
    
    

    
}