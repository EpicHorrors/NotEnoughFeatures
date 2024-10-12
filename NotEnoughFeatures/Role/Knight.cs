using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Knight : CrewmateRole, ICustomRole
{
    public string RoleName => "Knight";
    public string RoleLongDescription => "Kill One Imposter";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.CrewmateBlue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        
        CanUseVent = false,
    };

}