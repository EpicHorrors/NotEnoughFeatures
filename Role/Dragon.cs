using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Dragon : ImpostorRole, ICustomRole
{
    public string RoleName => "Dragon";
    public string RoleLongDescription => "Let Them Burn";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.Orange;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        CanUseSabotage = true,
    };
}