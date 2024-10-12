using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using NotEnoughFeatures.Role;
using System;

namespace NotEnoughFeatures.Options.NorthernBreeze;

public class ChatOptions : AbstractOptionGroup
{
    public override string GroupName => "CommandsOptions";

    

    

    [ModdedToggleOption("Can Use Commands")]
    public bool Command { get; set; } = false;


}

