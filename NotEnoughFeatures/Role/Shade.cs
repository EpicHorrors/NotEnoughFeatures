using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Shade : ImpostorRole, ICustomRole
{
    public string RoleName => "Shade";
    public string RoleLongDescription => "Absorb Everything";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.Purple;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        UseVanillaKillButton = false,
        
    };


}