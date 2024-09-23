using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class Virus : ImpostorRole, ICustomRole
{
    public string RoleName => "Virus";
    public string RoleLongDescription => "Infect To The Last Person";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.CrewmateRoleHeaderVeryDarkBlue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        CanUseSabotage = true,
    };
}