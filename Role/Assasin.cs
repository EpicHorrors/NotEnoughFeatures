using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Assasin : ImpostorRole, ICustomRole
{
    public string RoleName => "Assasin";
    public string RoleLongDescription => "Assasinate Everyone";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.Purple;
    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        UseVanillaKillButton = false,
        
    };

}