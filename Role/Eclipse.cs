using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class Eclipse : ImpostorRole, ICustomRole
{
    public string RoleName => "Eclipse";
    public string RoleLongDescription => "Darken The Sky";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.Blue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        UseVanillaKillButton = false,
        
    };


}