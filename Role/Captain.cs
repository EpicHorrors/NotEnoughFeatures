using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Captain : ImpostorRole, ICustomRole
{
    public string RoleName => "Captain";
    public string RoleLongDescription => "Control The Ship";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.LightBlue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        CanGetKilled = true,
        CanUseVent = true,
    };

}