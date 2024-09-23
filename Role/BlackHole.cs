using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class BlackHole : ImpostorRole, ICustomRole
{
    public string RoleName => "BlackHole";
    public string RoleLongDescription => "Absorb The World";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.CrewmateRoleHeaderVeryDarkBlue;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        UseVanillaKillButton = true,
        
        CanUseVent = true,
    };
}