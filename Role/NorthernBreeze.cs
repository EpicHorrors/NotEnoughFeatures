using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class NothernBreeze : ImpostorRole, ICustomRole
{
    public string RoleName => "NorthernBreeze";
    public string RoleLongDescription => "Freeze Them All";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.LightBlue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        CanUseSabotage = true,
    };
}