using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Sniper : ImpostorRole, ICustomRole
{
    public string RoleName => "Sniper";
    public string RoleLongDescription => "Snipe The Imposters, Don't Misfire";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.CrewmateRoleHeaderDarkBlue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        
        CanUseVent = true,
    };

}